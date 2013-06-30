using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Water_Board_Management_HelpDesk
{
    class Converter
    {
        //Stores a Complaint object in the database
		public void storeComplaint(Water_Board_Management.Database d,Complaint cmp)
        {
            Water_Board_Management.ComplaintRow cr = new Water_Board_Management.ComplaintRow(cmp.getReference(), cmp.getAccount(), cmp.getType(), cmp.getSub(), cmp.getAdd(), cmp.isCompleted(), cmp.getSubmit(), cmp.getComplete(), cmp.getProgress(), cmp.getPriority());
            d.insert(cr);
        }

        //Retrieves the Complaint object with the given reference number from the database
		public Complaint retComplaint(Water_Board_Management.Database d,String rn)
        {
            if (!(d.hasEntry(rn)))
                return null;
            
            String[] det = d.getRow(rn);
            Complaint temp = new Complaint(Int32.Parse(det[0]), Int32.Parse(det[1]), det[2], det[3], det[4], det[6]);
            if (det[5].Equals("True"))
            {
                temp.complete();
                temp.setComplete(det[7]);                
            }
            temp.setProgress(det[8]);
            temp.setPriority(Int32.Parse(det[9]));

            return temp;
        }

		//Stores an Appeal object in the database
        public void storeAppeal(Water_Board_Management.Database d, Appeal apl)
        {
            Water_Board_Management.AppealRow ar = new Water_Board_Management.AppealRow(apl.getReference(), apl.getAccount(), apl.getType(), apl.getSub(), apl.getAdd(), apl.isCompleted(), apl.getSubmit(), apl.getComplete(), apl.getProgress(), apl.isValidated());
            d.insert(ar);
        }

		//Retrieves the Appeal object with the given reference number from the database
        public Appeal retAppeal(Water_Board_Management.Database d, String rn)
        {
            if (!(d.hasEntry(rn)))
                return null;

            String[] det = d.getRow(rn);            
            Appeal temp = new Appeal(Int32.Parse(det[0]), Int32.Parse(det[1]), det[2], det[3], det[6]);
            if (det[5].Equals("True"))
            {
                temp.complete();
                temp.setComplete(det[7]);
            }
            if (det[9].Equals("True"))
                temp.validate();
            temp.setAdditional(det[4]);
            temp.setProgress(det[8]);

            return temp;
        }
    }
}
