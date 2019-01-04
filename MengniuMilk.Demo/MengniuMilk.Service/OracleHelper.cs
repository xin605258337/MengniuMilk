using System;
using System.Data;
using System.Data.OracleClient;
using System.Collections;
using System.Reflection;
using System.Configuration;

/// <summary>  
/// ConnDbForOracle ��ժҪ˵����  
/// </summary>  
public class ConnForOracle
{
    protected OracleConnection Connection;
    private string connectionString;
    public ConnForOracle()
    {
        string connStr;
        connStr = ConfigurationManager.ConnectionStrings["connString"].ToString();
        connectionString = connStr;
        Connection = new OracleConnection(connectionString);
    }

    #region �������Ĺ��캯��  
    /// <summary>  
    /// �������Ĺ��캯��  
    /// </summary>  
    /// <param name="ConnString">���ݿ������ַ���</param>  
    public ConnForOracle(string ConnString)
    {
        string connStr;
        connStr = System.Configuration.ConfigurationSettings.AppSettings[ConnString].ToString();
        Connection = new OracleConnection(connStr);
    }
    #endregion

    #region �����ݿ�  
    /// <summary>  
    /// �����ݿ�  
    /// </summary>  
    public void OpenConn()
    {
        if (this.Connection.State != ConnectionState.Open)
            this.Connection.Open();
    }
    #endregion
    #region �ر����ݿ�����  
    /// <summary>  
    /// �ر����ݿ�����  
    /// </summary>  
    public void CloseConn()
    {
        if (Connection.State == ConnectionState.Open)
            Connection.Close();
    }
    #endregion

    #region ִ��SQL��䣬�������ݵ�DataSet��  
    /// <summary>  
    /// ִ��SQL��䣬�������ݵ�DataSet��  
    /// </summary>  
    /// <param name="sql">sql���</param>  
    /// <param name="DataSetName">�Զ��巵�ص�DataSet����</param>  
    /// <returns>����DataSet</returns>  
    public DataTable ReturnDataSet(string sql)
    {
        DataSet dataSet = new DataSet();
        OpenConn();
        OracleDataAdapter OraDA = new OracleDataAdapter(sql, Connection);
        OraDA.Fill(dataSet);
        //   CloseConn();  
        return dataSet.Tables[0];
    }
    #endregion

    #region ִ��Sql���,���ش���ҳ���ܵ�dataset  
    /// <summary>  
    /// ִ��Sql���,���ش���ҳ���ܵ�dataset  
    /// </summary>  
    /// <param name="sql">Sql���</param>  
    /// <param name="PageSize">ÿҳ��ʾ��¼��</param>  
    /// <param name="CurrPageIndex"><��ǰҳ/param>  
    /// <param name="DataSetName">����dataset����</param>  
    /// <returns>����DataSet</returns>  
    public DataSet ReturnDataSet(string sql, int PageSize, int CurrPageIndex, string DataSetName)
    {
        DataSet dataSet = new DataSet();
        OpenConn();
        OracleDataAdapter OraDA = new OracleDataAdapter(sql, Connection);
        OraDA.Fill(dataSet, PageSize * (CurrPageIndex - 1), PageSize, DataSetName);
        //   CloseConn();  
        return dataSet;
    }
    #endregion

    #region ִ��SQL��䣬���� DataReader,��֮ǰһ��Ҫ��.read()��,Ȼ����ܶ�������  
    /// <summary>  
    /// ִ��SQL��䣬���� DataReader,��֮ǰһ��Ҫ��.read()��,Ȼ����ܶ�������  
    /// </summary>  
    /// <param name="sql">sql���</param>  
    /// <returns>����һ��OracleDataReader</returns>  
    public OracleDataReader ReturnDataReader(String sql)
    {
        OpenConn();
        OracleCommand command = new OracleCommand(sql, Connection);
        return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
    }
    #endregion

    #region ִ��SQL��䣬���ؼ�¼������  
    /// <summary>  
    /// ִ��SQL��䣬���ؼ�¼������  
    /// </summary>  
    /// <param name="sql">sql���</param>  
    /// <returns>���ؼ�¼������</returns>  
    public int GetRecordCount(string sql)
    {
        int recordCount = 0;
        OpenConn();
        OracleCommand command = new OracleCommand(sql, Connection);
        OracleDataReader dataReader = command.ExecuteReader();
        while (dataReader.Read())
        {
            recordCount++;
        }
        dataReader.Close();
        //   CloseConn();  
        return recordCount;
    }
    #endregion

    #region ȡ��ǰ����,����Ϊseq.nextval��seq.currval  
    /// <summary>  
    /// ȡ��ǰ����  
    /// </summary>  
    /// <param name="seqstr"></param>  
    /// <param name="table"></param>  
    /// <returns></returns>  
    public decimal GetSeq(string seqstr)
    {
        decimal seqnum = 0;
        string sql = "select " + seqstr + " from dual";
        OpenConn();
        OracleCommand command = new OracleCommand(sql, Connection);
        OracleDataReader dataReader = command.ExecuteReader();
        if (dataReader.Read())
        {
            seqnum = decimal.Parse(dataReader[0].ToString());
        }
        dataReader.Close();
        //   CloseConn();  
        return seqnum;
    }
    #endregion

    #region ִ��SQL���,������Ӱ�������  
    /// <summary>  
    /// ִ��SQL���,������Ӱ�������  
    /// </summary>  
    /// <param name="sql"></param>  
    /// <returns></returns>  
    public int ExecuteSQL(string sql)
    {
        int Cmd = 0;
        OpenConn();
        OracleCommand command = new OracleCommand(sql, Connection);
        try
        {
            Cmd = command.ExecuteNonQuery();
        }
        catch
        {

        }
        finally
        {
            //    CloseConn();  
        }

        return Cmd;
    }
    #endregion

    //����������������������������������������������������������������������������������������   
    //��������hashTable�����ݿ����insert,update,del����,ע���ʱֻ����Ĭ�ϵ����ݿ�����"connstr"����  
    //������������������������������������������������������������������������������������������  

    #region ���ݱ�������ϡ���Զ��������ݿ� �÷���Insert("test",ht)  
    public int Insert(string TableName, Hashtable ht)
    {
        OracleParameter[] Parms = new OracleParameter[ht.Count];
        IDictionaryEnumerator et = ht.GetEnumerator();
        DataTable dt = GetTabType(TableName);
        System.Data.OracleClient.OracleType otype;
        int size = 0;
        int i = 0;

        while (et.MoveNext()) // ����ϣ��ѭ��  
        {
            GetoType(et.Key.ToString().ToUpper(), dt, out otype, out size);
            System.Data.OracleClient.OracleParameter op = MakeParam(":" + et.Key.ToString(), otype, size, et.Value.ToString());
            Parms[i] = op; // ���SqlParameter����  
            i = i + 1;
        }
        string str_Sql = GetInsertSqlbyHt(TableName, ht); // ��ò���sql���  
        int val = ExecuteNonQuery(str_Sql, Parms);
        return val;
    }
    #endregion

    #region ����������������ݿ���и��²��� �÷���Update("test","Id=:Id",ht);   
    public int Update(string TableName, string ht_Where, Hashtable ht)
    {
        OracleParameter[] Parms = new OracleParameter[ht.Count];
        IDictionaryEnumerator et = ht.GetEnumerator();
        DataTable dt = GetTabType(TableName);
        System.Data.OracleClient.OracleType otype;
        int size = 0;
        int i = 0;
        // ����ϣ��ѭ��  
        while (et.MoveNext())
        {
            GetoType(et.Key.ToString().ToUpper(), dt, out otype, out size);
            System.Data.OracleClient.OracleParameter op = MakeParam(":" + et.Key.ToString(), otype, size, et.Value.ToString());
            Parms[i] = op; // ���SqlParameter����  
            i = i + 1;
        }
        string str_Sql = GetUpdateSqlbyHt(TableName, ht_Where, ht); // ��ò���sql���  
        int val = ExecuteNonQuery(str_Sql, Parms);
        return val;
    }
    #endregion

    #region del����,ע��˴�����������hash���������Ӧ��һ�� �÷���Del("test","Id=:Id",ht)  
    public int Del(string TableName, string ht_Where, Hashtable ht)
    {
        OracleParameter[] Parms = new OracleParameter[ht.Count];
        IDictionaryEnumerator et = ht.GetEnumerator();
        DataTable dt = GetTabType(TableName);
        System.Data.OracleClient.OracleType otype;
        int i = 0;
        int size = 0;
        // ����ϣ��ѭ��  
        while (et.MoveNext())
        {
            GetoType(et.Key.ToString().ToUpper(), dt, out otype, out size);
            System.Data.OracleClient.OracleParameter op = MakeParam(":" + et.Key.ToString(), et.Value.ToString());
            Parms[i] = op; // ���SqlParameter����  
            i = i + 1;
        }
        string str_Sql = GetDelSqlbyHt(TableName, ht_Where, ht); // ���ɾ��sql���  
        int val = ExecuteNonQuery(str_Sql, Parms);
        return val;
    }
    #endregion

    //����������������������������������������������������������������������������������������  
    //���������������������������������ڲ����ú���������������������������������������  
    //����������������������������������������������������������������������������������������  

    #region ���ݹ�ϡ�������Զ�������Ӧinsert���(�������͵�)  
    /// <summary>  
    /// ���ݹ�ϡ�������Զ�������Ӧinsert���  
    /// </summary>  
    /// <param name="TableName">Ҫ����ı���</param>  
    /// <param name="ht">��ϡ��</param>  
    /// <returns>����sql���</returns>  
    public static string GetInsertSqlbyHt(string TableName, Hashtable ht)
    {
        string str_Sql = "";
        int i = 0;
        int ht_Count = ht.Count; // ��ϣ�����  
        IDictionaryEnumerator myEnumerator = ht.GetEnumerator();
        string before = "";
        string behide = "";
        while (myEnumerator.MoveNext())
        {
            if (i == 0)
            {
                before = "(" + myEnumerator.Key;
            }
            else if (i + 1 == ht_Count)
            {
                before = before + "," + myEnumerator.Key + ")";
            }
            else
            {
                before = before + "," + myEnumerator.Key;
            }
            i = i + 1;
        }
        behide = " Values" + before.Replace(",", ",:").Replace("(", "(:");
        str_Sql = "Insert into " + TableName + before + behide;
        return str_Sql;
    }
    #endregion

    #region ���ݱ�����where��������ϡ���Զ����ɸ������(�������͵�)  
    public static string GetUpdateSqlbyHt(string Table, string ht_Where, Hashtable ht)
    {
        string str_Sql = "";
        int i = 0;
        int ht_Count = ht.Count; // ��ϣ�����  
        IDictionaryEnumerator myEnumerator = ht.GetEnumerator();
        while (myEnumerator.MoveNext())
        {
            if (i == 0)
            {
                if (ht_Where.ToString().ToLower().IndexOf((myEnumerator.Key + "=:" + myEnumerator.Key).ToLower()) == -1)
                {
                    str_Sql = myEnumerator.Key + "=:" + myEnumerator.Key;
                }
            }
            else
            {
                if (ht_Where.ToString().ToLower().IndexOf((":" + myEnumerator.Key + " ").ToLower()) == -1)
                {
                    str_Sql = str_Sql + "," + myEnumerator.Key + "=:" + myEnumerator.Key;
                }

            }
            i = i + 1;
        }
        if (ht_Where == null || ht_Where.Replace(" ", "") == "")  // ����ʱ��û������  
        {
            str_Sql = "update " + Table + " set " + str_Sql;
        }
        else
        {
            str_Sql = "update " + Table + " set " + str_Sql + " where " + ht_Where;
        }
        str_Sql = str_Sql.Replace("set ,", "set ").Replace("update ,", "update ");
        return str_Sql;
    }
    #endregion

    #region ���ݱ�����where��������ϡ���Զ�����del���(�������͵�)  
    public static string GetDelSqlbyHt(string Table, string ht_Where, Hashtable ht)
    {
        string str_Sql = "";
        int i = 0;

        int ht_Count = ht.Count; // ��ϣ�����  
        IDictionaryEnumerator myEnumerator = ht.GetEnumerator();
        while (myEnumerator.MoveNext())
        {
            if (i == 0)
            {
                if (ht_Where.ToString().ToLower().IndexOf((myEnumerator.Key + "=:" + myEnumerator.Key).ToLower()) == -1)
                {
                    str_Sql = myEnumerator.Key + "=:" + myEnumerator.Key;
                }
            }
            else
            {
                if (ht_Where.ToString().ToLower().IndexOf((":" + myEnumerator.Key + " ").ToLower()) == -1)
                {
                    str_Sql = str_Sql + "," + myEnumerator.Key + "=:" + myEnumerator.Key;
                }

            }
            i = i + 1;
        }
        if (ht_Where == null || ht_Where.Replace(" ", "") == "")  // ����ʱ��û������  
        {
            str_Sql = "Delete " + Table;
        }
        else
        {
            str_Sql = "Delete " + Table + " where " + ht_Where;
        }
        return str_Sql;
    }
    #endregion

    #region ����Oracle����  
    /// <summary>  
    /// ����oracle����  
    /// </summary>  
    /// <param name="ParamName">�ֶ���</param>  
    /// <param name="otype">��������</param>  
    /// <param name="size">���ݴ�С</param>  
    /// <param name="Value">ֵ</param>  
    /// <returns></returns>  
    public static OracleParameter MakeParam(string ParamName, System.Data.OracleClient.OracleType otype, int size, Object Value)
    {
        OracleParameter para = new OracleParameter(ParamName, Value);
        para.OracleType = otype;
        para.Size = size;
        return para;
    }
    #endregion

    #region ����oracle����  
    public static OracleParameter MakeParam(string ParamName, string Value)
    {
        return new OracleParameter(ParamName, Value);
    }
    #endregion

    #region ���ݱ�ṹ�ֶε����ͺͳ���ƴװoracle sql������  
    public static void GetoType(string key, DataTable dt, out System.Data.OracleClient.OracleType otype, out int size)
    {

        DataView dv = dt.DefaultView;
        dv.RowFilter = "column_name='" + key + "'";
        string fType = dv[0]["data_type"].ToString().ToUpper();
        switch (fType)
        {
            case "DATE":
                otype = OracleType.DateTime;
                size = int.Parse(dv[0]["data_length"].ToString());
                break;
            case "CHAR":
                otype = OracleType.Char;
                size = int.Parse(dv[0]["data_length"].ToString());
                break;
            case "LONG":
                otype = OracleType.Double;
                size = int.Parse(dv[0]["data_length"].ToString());
                break;
            case "NVARCHAR2":
                otype = OracleType.NVarChar;
                size = int.Parse(dv[0]["data_length"].ToString());
                break;
            case "VARCHAR2":
                otype = OracleType.NVarChar;
                size = int.Parse(dv[0]["data_length"].ToString());
                break;
            default:
                otype = OracleType.NVarChar;
                size = 100;
                break;
        }
    }
    #endregion

    #region ��̬ ȡ�����ֶε����ͺͳ���,�˴�û�ж�̬�õ�connstr,��Ĭ�ϵģ�by/����  
    public System.Data.DataTable GetTabType(string tabnale)
    {
        string sql = "select  column_name,data_type,data_length from all_tab_columns where table_name='" + tabnale.ToUpper() + "'";
        OpenConn();
        return ReturnDataSet(sql);

    }
    #endregion

    #region ִ��sql���   
    public int ExecuteNonQuery(string cmdText, params OracleParameter[] cmdParms)
    {

        OracleCommand cmd = new OracleCommand();
        OpenConn();
        cmd.Connection = Connection;
        cmd.CommandText = cmdText;
        if (cmdParms != null)
        {
            foreach (OracleParameter parm in cmdParms)
                cmd.Parameters.Add(parm);
        }
        int val = cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        //   conn.CloseConn();  
        return val;
    }
    #endregion

    //����������������������������������������������������������������������������  
    //���������������������ڲ����ú����ꣽ��������������������������������������  

    //��������������������������������������������������������������������������  
}