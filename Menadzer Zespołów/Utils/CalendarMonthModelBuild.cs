using Menadzer_Zespołów.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Menadzer_Zespołów.Utils
{
    public class CalendarMonthModelBuild
    {
        private static DateTime firstDayOfMonth;
        private static int firstDayOfMonthNumber;

        private static List<DayModel> weekDayNames = new List<DayModel>();


        public static DayModel[] Create(DateTime dateTimeNow)
        {
            // set date to first day of month
            firstDayOfMonth = dateTimeNow.AddDays(-(dateTimeNow.Day - 1));

            // check what number of day of week have first day of month
            firstDayOfMonthNumber = (int)firstDayOfMonth.DayOfWeek;

            // this is needed only for first loop to set where in start of calendar
            int numberOfFirstDay = -1;

            // two dimension because is 7 days per week and sometimes needed is 6 row of calendar for one month
            DayModel[] monthView = new DayModel[42];

            for (int i = 0; i < 42; i++)
            {
                if (numberOfFirstDay == -1)
                {
                    switch (firstDayOfMonthNumber)
                    {
                        case 1:
                            monthView[0] = new DayModel(firstDayOfMonth);
                            numberOfFirstDay = 0;
                            break;
                        case 2:
                            monthView[1] = new DayModel(firstDayOfMonth);
                            numberOfFirstDay = 1;
                            break;
                        case 3:
                            monthView[2] = new DayModel(firstDayOfMonth);
                            numberOfFirstDay = 2;
                            break;
                        case 4:
                            monthView[3] = new DayModel(firstDayOfMonth);
                            numberOfFirstDay = 3;
                            break;
                        case 5:
                            monthView[4] = new DayModel(firstDayOfMonth);
                            numberOfFirstDay = 4;
                            break;
                        case 6:
                            monthView[5] = new DayModel(firstDayOfMonth);
                            numberOfFirstDay = 5;
                            break;
                        case 0:
                            monthView[6] = new DayModel(firstDayOfMonth);
                            numberOfFirstDay = 6;
                            break;
                        default:
                            break;
                    }
                    i = numberOfFirstDay;
                }
                else
                {

                    firstDayOfMonth = firstDayOfMonth.AddDays(1);
                    monthView[i] = new DayModel(firstDayOfMonth);

                }
            }
            // set empty field before first day of month in monthView table
            if (numberOfFirstDay != 0)
            {
                firstDayOfMonth = dateTimeNow.AddDays(-(dateTimeNow.Day - 1));
                for (int i = numberOfFirstDay - 1; i >= 0; i--)
                {
                    firstDayOfMonth = firstDayOfMonth.AddDays(-1);
                    monthView[i] = new DayModel(firstDayOfMonth);
                }
            }
            Debug.Print("Model kalendarz utworzony");
            return monthView;
        }

        public static List<DayModel> GenerateWeekNameList(DayModel[] dayModels)
        {
            for (int i = 0; i < 7; i++)
            {
                weekDayNames.Add(dayModels[i]);
            }
            
            return weekDayNames;
        }

    }


}
