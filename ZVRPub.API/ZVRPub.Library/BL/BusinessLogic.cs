﻿using System;
using System.Collections.Generic;
using System.Text;
using ZVRPub.Scaffold;
using ZVRPub.Repository;
namespace ZVRPub.Library.BL
{
    public class BusinessLogic
    {
        

        public int years(DateTime start, DateTime end)
        {
            return (end.Year - start.Year - 1) +
                (((end.Month > start.Month) ||
                ((end.Month == start.Month) && (end.Day >= start.Day))) ? 1 : 0);
        }

        public bool AgeCheck(Users user)
        {
            bool ageCheck = true;
            DateTime today = DateTime.Now;
            DateTime birthday = user.DateOfBirth;
            int checkYear = years(birthday, today); 
            if(checkYear <= 20)
            {
                ageCheck = false;
            }
            return ageCheck;
        }
        public void HappyHour(DateTime Today)
        {
            
            
            switch (Today.DayOfWeek)
            {
                case DayOfWeek.Monday:
                  
                    break;

                case DayOfWeek.Tuesday:
                  
                    break;

                case DayOfWeek.Wednesday:
                  
                    break;
                case DayOfWeek.Friday:
                    
                    break;
                
            }
           

        }


        
    }
}
