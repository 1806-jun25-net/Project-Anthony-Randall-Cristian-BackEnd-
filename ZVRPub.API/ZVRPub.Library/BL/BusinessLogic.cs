using System;
using System.Collections.Generic;
using System.Text;
using ZVRPub.Scaffold;
using ZVRPub.Repository;
namespace ZVRPub.Library.BL
{
    public class BusinessLogic
    {
        private readonly IZVRPubRepository Repo; 

        public bool AgeCheck(int UsersYear,int UsersMonth, DateTime Today)
        {
            bool ageCheck = true;
            int checkYear = Today.Year - UsersYear; 
            if(checkYear <= 21)
            {
                if(!(checkYear == 20 && UsersMonth == Today.Month))
                {
                    ageCheck = false;
                }
               
            }
            return ageCheck;
        }
        public void HappyHour(DateTime Today)
        {
            
            
            switch (Today.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    Repo.UpdatePreBuiltMenu("Wrap", 4);
                    break;

                case DayOfWeek.Tuesday:
                    Repo.UpdatePreBuiltMenu("Tacos", 1);
                    break;

                case DayOfWeek.Wednesday:
                    Repo.UpdatePreBuiltMenu("Burger", 5);
                    break;
                case DayOfWeek.Friday:
                    //all drinks half off
                    break;
                
            }
           

        }


        
    }
}
