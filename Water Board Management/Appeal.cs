using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Water_Board_Management_HelpDesk
{
    class Appeal
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
        private bool validated;

        public Appeal(int refN,int acc, String typ, String subTyp,String sub)
        {
            reference = refN;
            account = acc;
            complainType = typ;
            subType = subTyp;
            additionalInfo = "";
            submmitedOn = sub;
            validated = false;
            completed = false;
            progress = "";            
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

        public bool isValidated()
        {
            return validated;
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

        public void setProgress(String pro)
        {
            progress = pro;
        }

        public void validate()				//validates the appeal
        {
            validated = true;
        }
        public void complete()				//completes the appeal
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

        public void setAdditional(String a)
        {
            additionalInfo = a;
        }
    }
}
