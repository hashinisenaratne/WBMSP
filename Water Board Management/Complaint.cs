using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Water_Board_Management_HelpDesk
{
    class Complaint
    {
        private int reference;
        private int account;
        private String complainType;
        private String subType;
        private String additionalInfo;
        private Boolean completed;
        private String submmitedOn;
        private String completedOn;
        private String progress;
        private int priority;

        public Complaint(int refN,int acc, String typ, String subTyp, String add,String sub)
        {
            reference = refN;
            account = acc;
            complainType = typ;
            subType = subTyp;
            additionalInfo = add;
            submmitedOn = sub;
            completed = false;
            progress = "";
            priority = 0;
        }
        public Complaint(int refN,int acc, String typ, String subTyp,String sub)
        {
            reference = refN;
            account = acc;
            complainType = typ;
            subType = subTyp;
            additionalInfo = "";
            submmitedOn = sub;
            completed = false;
            progress = "";
            priority = 0;
        }

        public int getReference()
        {
            return reference;
        }

        public int getAccount()
        {
            return account;
        }

        public String getType()
        {
            return complainType;
        }

        public String getSub()
        {
            return subType;
        }

        public String getAdd()
        {
            return additionalInfo;
        }

        public bool isCompleted()
        {
            return completed;
        }

        public String getComplete()
        {
            return completedOn;
        }

        public String getSubmit()
        {
            return submmitedOn;
        }

        public String getProgress()
        {
            return progress;
        }

        public int getPriority()
        {
            return priority;
        }

        public void setProgress(String pro)
        {
            progress = pro;
        }

        public void complete()
        {
            completed = true;
            completedOn = date(DateTime.Today);
        }

        public void setComplete(String c)
        {
            completedOn = c;
        }

        private String date(DateTime d)
        {
            return (d.Year.ToString()+"-"+d.Month.ToString()+"-"+d.Day.ToString());
        }

        public void setPriority(int p)
        {
            priority = p;
        }
    }
}
