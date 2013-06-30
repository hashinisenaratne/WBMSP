using System;
using MySql.Data.MySqlClient;

namespace Water_Board_Management
{
    class Database
    {
        MySqlDataReader Reader;
        MySqlConnection connection;
        MySqlCommand command;
        String table;
        String key;

        public Database(String table, String key)
        {
            this.table = table;
            this.key = key;
            connect();
        }

        private void connect()
        {
            String connectionString = "SERVER=db4free.net;DATABASE=wbms;UID=isoft;PASSWORD=isoftsolutions;";
            //String connectionString = "SERVER=localhost;DATABASE=wbms;UID=root;PASSWORD=root;";
            connection = new MySqlConnection(connectionString);
            command = connection.CreateCommand();
            connection.Open();

        }

        public void insert(Row row)
        {
            command.CommandText = "INSERT INTO " + table + " VALUES (" + row.toString() + ");";
            command.ExecuteNonQuery();
        }

        public void delete(String keyValue)
        {
            command.CommandText = "DELETE FROM " + table + " WHERE " + key + " = '" + keyValue + "';";
            command.ExecuteNonQuery();
        }

        public String get(String column, String keyValue)
        {
            command.CommandText = "select " + column + " from " + table + " where " + key + "='" + keyValue + "'";
            Reader = command.ExecuteReader();
            Reader.Read();
            String ret = Reader.GetString(0);
            Reader.Close();
            return ret;
        }

        public String[] getRow(String keyValue)
        {
            command.CommandText = "select * from " + table + " where " + key + "='" + keyValue + "'";
            Reader = command.ExecuteReader();
            String[] ret = new String[Reader.FieldCount];
            for (int i = 0; i < Reader.FieldCount; i++)
            {
                Reader.Read();
                ret[i] = Reader.GetString(i);
            }
            Reader.Close();
            return ret;
        }

        public bool hasEntry(String keyValue)
        {
            command.CommandText = "select * from " + table + " where " + key + "='" + keyValue + "'";
            Reader = command.ExecuteReader();
            bool ret = Reader.HasRows;
            Reader.Close();
            return ret;
        }

        public void update(String column, String keyValue, String newValue)
        {
            command.CommandText = "UPDATE " + table + " SET " + column + " = '" + newValue + "' WHERE " + key + " = '" + keyValue + "'";
            command.ExecuteNonQuery();
        }

        public void updateMany(String[] columns, String keyValue, String[] newValues)
        {
            command.CommandText = "UPDATE " + table + " SET ";
            for (int i = 0; i < columns.Length; i++)
            {
                command.CommandText += columns[i] + " = '" + newValues[i] + "'";
                if (i != columns.Length - 1)
                    command.CommandText += ",";
            }
            command.CommandText += " WHERE " + key + " = '" + keyValue + "'";
            command.ExecuteNonQuery();
        }

        public String[] getColumn(String columnName)
        {
            command.CommandText = "select count(*) from " + table + ";";
            Reader = command.ExecuteReader();
            Reader.Read();
            int count = Reader.GetInt32(0);
            Reader.Close();
            String[] ret = new String[count];
            command.CommandText = "select " + columnName + " from " + table + ";";
            Reader = command.ExecuteReader();
            for (int i = 0; i < count; i++)
            {
                Reader.Read();
                ret[i] = Reader.GetString(0);
            }
            Reader.Close();
            return ret;
        }

        public void createBillingTable(int accountNo)
        {
            command.CommandText = "create table a" + accountNo.ToString() + " (month varchar(15),units int,amount double,remarks varchar(100));";
            command.ExecuteNonQuery();
        }

        public String[] getlike(String columnName, String keyValue)
        {
            command.CommandText = "select count(*) from " + table + "WHERE " + key + " LIKE '%" + keyValue + "'" + ";";
            Reader = command.ExecuteReader();
            Reader.Read();
            int count = Reader.GetInt32(0);
            Reader.Close();
            String[] ret = new String[count];
            command.CommandText = "select " + columnName + " from " + table + " WHERE " + key + " LIKE '%" + keyValue + "'" + ";";
            Reader = command.ExecuteReader();
            for (int i = 0; i < count; i++)
            {
                Reader.Read();
                ret[i] = Reader.GetString(0);
            }
            Reader.Close();
            return ret;
        }

        public String[] getColumnEqualsWhereKeyIsLike(String columnName, String keylikeValue, String keyequal, String keyequalValue)
        {
            command.CommandText = "select count(*) from " + table + "WHERE " + key + " LIKE '%" + keylikeValue + "%' && " + keyequal + "='" + keyequalValue + "'" + ";";
            Reader = command.ExecuteReader();
            Reader.Read();
            int count = Reader.GetInt32(0);
            Reader.Close();
            String[] ret = new String[count];
            command.CommandText = "select " + columnName + " from " + table + " WHERE " + key + " LIKE '%" + keylikeValue + "%' && " + keyequal + "='" + keyequalValue + "'" + ";";
            Reader = command.ExecuteReader();
            for (int i = 0; i < count; i++)
            {
                Reader.Read();
                ret[i] = Reader.GetString(0);
            }
            Reader.Close();
            return ret;
        }


        public bool hasEntry(String keylikeValue, String keyequal, String keyequalValue)
        {
            command.CommandText = "select * from " + table + " WHERE " + key + " LIKE '%" + keylikeValue + "%' && " + keyequal + "='" + keyequalValue + "'" + ";";
            Reader = command.ExecuteReader();
            bool ret = Reader.HasRows;
            Reader.Close();
            return ret;
        }

    }

    public interface Row
    {
        String toString();
    }

    public class LoginRow : Row
    {
        private String username;
        private String password;
        private short auth_level;

        public LoginRow(String username, String password, short auth_level)
        {
            this.username = username;
            this.password = password;
            this.auth_level = auth_level;
        }

        public String toString()
        {
            return "'" + username + "', '" + password + "', '" + auth_level.ToString() + "'";
        }
    }

    public class ApplicationRow : Row
    {
        private String title;
        private String name;
        private String nic;
        private String category;
        private String address;
        private String gramaDivision;
        private String divisionalSecretariat;
        private String district;
        private String mail;
        private String email;
        private int contact;
        private String applicantType;
        private short submittedDocs;
        private String preaccountNo;
        private String preCategory;
        private int refno;
        private String company;
        private String post;
        private int confirmG;//0-not yet,1-confirmed,2-rejected
        private int confirmA;//0-not yet,1-confirmed,2-rejected

        public ApplicationRow(String title, String name, String nic, String category, String address, String gramaDivision, String divisionalSecretariat, String district, String mail, String email, int contact, String applicantType, bool submittedDocs, String preaccountNo, String preCategory, int refno, String company, String post, int confirmG, int confirmA)
        {
            this.title = title;
            this.name = name;
            this.nic = nic;
            this.category = category;
            this.address = address;
            this.gramaDivision = gramaDivision;
            this.divisionalSecretariat = divisionalSecretariat;
            this.district = district;
            this.mail = mail;
            this.email = email;
            this.contact = contact;
            this.applicantType = applicantType;
            if (submittedDocs)
                this.submittedDocs = 1;
            else
                this.submittedDocs = 0;
            this.preaccountNo = preaccountNo;
            this.preCategory = preCategory;
            this.refno = refno;
            this.company = company;
            this.post = post;
            this.confirmG = confirmG;
            this.confirmA = confirmA;
        }

        public String toString()
        {
            return "'" + title + "', '" + name + "', '" + nic + "', '" + category + "', '" + address + "', '" + gramaDivision + "', '" + divisionalSecretariat + "', '" + district + "', '" + mail + "', '" + email + "', '" + contact + "', '" + applicantType + "', '" + submittedDocs + "', '" + preaccountNo + "', '" + preCategory + "', '" + refno + "', '" + company + "', '" + post + "', '" + confirmG + "', '" + confirmA + "'";
        }

    }


    public class InProgressRow : Row
    {
        private String title;
        private String name;
        private String nic;
        private String category;
        private String address;
        private String gramaDivision;
        private String divisionalSecretariat;
        private String district;
        private String mail;
        private String email;
        private int contact;
        private String applicantType;
        private short submittedDocs;
        private String preaccountNo;
        private String preCategory;
        private int refno;
        private String company;
        private String post;
        private String progress;
        private String estimateSummary;

        public InProgressRow(String title, String name, String nic, String category, String address, String gramaDivision, String divisionalSecretariat, String district, String mail, String email, int contact, String applicantType, bool submittedDocs, String preaccountNo, String preCategory, int refno, String company, String post, String progress, String estimateSummary)
        {
            this.title = title;
            this.name = name;
            this.nic = nic;
            this.category = category;
            this.address = address;
            this.gramaDivision = gramaDivision;
            this.divisionalSecretariat = divisionalSecretariat;
            this.district = district;
            this.mail = mail;
            this.email = email;
            this.contact = contact;
            this.applicantType = applicantType;
            if (submittedDocs)
                this.submittedDocs = 1;
            else
                this.submittedDocs = 0;
            this.preaccountNo = preaccountNo;
            this.preCategory = preCategory;
            this.refno = refno;
            this.company = company;
            this.post = post;
            this.progress = progress;
            this.estimateSummary = estimateSummary;
        }

        public String toString()
        {
            return "'" + title + "', '" + name + "', '" + nic + "', '" + category + "', '" + address + "', '" + gramaDivision + "', '" + divisionalSecretariat + "', '" + district + "', '" + mail + "', '" + email + "', '" + contact + "', '" + applicantType + "', '" + submittedDocs + "', '" + preaccountNo + "', '" + preCategory + "', '" + refno + "', '" + company + "', '" + post + "', '" + progress + "', '" + estimateSummary + "'";
        }
    }

    public class MapnoRow : Row
    {
        private String category;
        private int no;

        public MapnoRow(String category, int no)
        {
            this.category = category;
            this.no = no;
        }

        public String toString()
        {
            return "'" + category + "', '" + no + "'";
        }
    }

    public class AccountRow : Row
    {
        private int accountNo;
        private String title;
        private String name;
        private String nic;
        private String category;
        private String address;
        private String gramaDivision;
        private String divisionalSecretariat;
        private String district;
        private String mail;
        private String email;
        private int contact;
        private String applicantType;
        private String company;
        private String post;
        int refno;

        public AccountRow(int accountNo, String title, String name, String nic, String category, String address, String gramaDivision, String divisionalSecretariat, String district, String mail, String email, int contact, String applicantType, String company, String post, int refno)
        {
            this.accountNo = accountNo;
            this.title = title;
            this.name = name;
            this.nic = nic;
            this.category = category;
            this.address = address;
            this.gramaDivision = gramaDivision;
            this.divisionalSecretariat = divisionalSecretariat;
            this.district = district;
            this.mail = mail;
            this.email = email;
            this.contact = contact;
            this.applicantType = applicantType;
            this.company = company;
            this.post = post;
            this.refno = refno;
        }

        public String toString()
        {
            return "'" + accountNo + "', '" + title + "', '" + name + "', '" + nic + "', '" + category + "', '" + address + "', '" + gramaDivision + "', '" + divisionalSecretariat + "', '" + district + "', '" + mail + "', '" + email + "', '" + contact + "', '" + applicantType + "', '" + company + "', '" + post + "', '" + refno + "'";
        }
    }

    public class ComplaintRow : Row
    {
        private int referenceNo;
        private int accountNo;
        private String complainType;
        private String subType;
        private String additionalInfo;
        private short completed;
        private String submmitedOn;
        private String completedOn;
        private String progress;
        private int priority;

        public ComplaintRow(int referenceNo, int accountNo, String complainType, String subType, String additionalInfo, bool completed, String submmitedOn, String completedOn, String progress, int priority)
        {
            this.referenceNo = referenceNo;
            this.accountNo = accountNo;
            this.complainType = complainType;
            this.subType = subType;
            this.additionalInfo = additionalInfo;
            if (completed)
                this.completed = 1;
            else
                this.completed = 0;
            this.submmitedOn = submmitedOn;
            this.completedOn = completedOn;
            this.progress = progress;
            this.priority = priority;
        }

        public String toString()
        {
            return "'" + referenceNo + "', '" + accountNo + "', '" + complainType + "', '" + subType + "', '" + additionalInfo + "', '" + completed + "', '" + submmitedOn + "', '" + completedOn + "', '" + progress + "', '" + priority + "'";
        }
    }

    public class AppealRow : Row
    {
        private int referenceNo;
        private int accountNo;
        private String complainType;
        private String subType;
        private String additionalInfo;
        private short completed;
        private String submmitedOn;
        private String completedOn;
        private String progress;
        private short validated;

        public AppealRow(int referenceNo, int accountNo, String complainType, String subType, String additionalInfo, bool completed, String submmitedOn, String completedOn, String progress, bool validated)
        {
            this.referenceNo = referenceNo;
            this.accountNo = accountNo;
            this.complainType = complainType;
            this.subType = subType;
            this.additionalInfo = additionalInfo;
            if (completed)
                this.completed = 1;
            else
                this.completed = 0;
            this.submmitedOn = submmitedOn;
            this.completedOn = completedOn;
            this.progress = progress;
            if (validated)
                this.validated = 1;
            else
                this.validated = 0;
        }
        public String toString()
        {
            return "'" + referenceNo + "', '" + accountNo + "', '" + complainType + "', '" + subType + "', '" + additionalInfo + "', '" + completed + "', '" + submmitedOn + "', '" + completedOn + "', '" + progress + "', '" + validated + "'";
        }
    }

    public class BillingRow : Row
    {
        private String month;
        private int units;
        private double amount;
        private String remarks;

        public BillingRow(String month, int units, double amount, String remarks)
        {
            this.month = month;
            this.units = units;
            this.amount = amount;
            this.remarks = remarks;
        }

        public String toString()
        {
            return "'" + month + "', '" + units + "', '" + amount + "', '" + remarks + "'";
        }
    }

    public class MailRow : Row
    {
        private int no;
        private String name;
        private String address;
        private String message;

        public MailRow(int no, String name, String address, String message)
        {
            this.no = no;
            this.name = name;
            this.address = address;
            this.message = message;
        }

        public String toString()
        {
            return "'" + no.ToString() + "', '" + name + "', '" + address + "', '" + message + "'";
        }
    }

    public class MeterRow : Row
    {
        private string month;
        private int bulkReading;
        private int usage;

        public MeterRow(string month, int bulkReading, int usage)
        {
            this.month = month;
            this.bulkReading = bulkReading;
            this.usage = usage;
        }

        public String toString()
        {
            return "'" + month + "', '" + bulkReading.ToString() + "', '" + usage.ToString() + "'";
        }
    }
}
