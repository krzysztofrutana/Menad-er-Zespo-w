using Menadzer_Zespołów.Database.Entities;
using Menadzer_Zespołów.Database.Repositiories;
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

       

        private static EventRepository eventRepository =  new EventRepository();

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

            string tempType;

            for (int i = 0; i < 42; i++)
            {
                
                if (numberOfFirstDay == -1)
                {
                    tempType = CheckTypeFromDataBase(firstDayOfMonth);
                    switch (firstDayOfMonthNumber)
                    {
                        case 1:
                            monthView[0] = new DayModel(firstDayOfMonth, tempType);
                            monthView[0].ItsDayInCurrentMonth = true;
                            numberOfFirstDay = 0;
                            break;
                        case 2:
                            monthView[1] = new DayModel(firstDayOfMonth, tempType);
                            monthView[1].ItsDayInCurrentMonth = true;
                            numberOfFirstDay = 1;
                            break;
                        case 3:
                            monthView[2] = new DayModel(firstDayOfMonth, tempType);
                            monthView[2].ItsDayInCurrentMonth = true;
                            numberOfFirstDay = 2;
                            break;
                        case 4:
                            monthView[3] = new DayModel(firstDayOfMonth, tempType);
                            monthView[3].ItsDayInCurrentMonth = true;
                            numberOfFirstDay = 3;
                            break;
                        case 5:
                            monthView[4] = new DayModel(firstDayOfMonth, tempType);
                            monthView[4].ItsDayInCurrentMonth = true;
                            numberOfFirstDay = 4;
                            break;
                        case 6:
                            monthView[5] = new DayModel(firstDayOfMonth, tempType);
                            monthView[5].ItsDayInCurrentMonth = true;
                            numberOfFirstDay = 5;
                            break;
                        case 0:
                            monthView[6] = new DayModel(firstDayOfMonth, tempType);
                            monthView[6].ItsDayInCurrentMonth = true;
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
                    tempType = CheckTypeFromDataBase(firstDayOfMonth);
                    monthView[i] = new DayModel(firstDayOfMonth, tempType);
                    if(dateTimeNow.Month == firstDayOfMonth.Month)
                    {
                        monthView[i].ItsDayInCurrentMonth = true;
                    }
                    else
                    {
                        monthView[i].ItsDayInCurrentMonth = false;
                    }

                }
            }
            // set empty field before first day of month in monthView table
            if (numberOfFirstDay != 0)
            {
                firstDayOfMonth = dateTimeNow.AddDays(-(dateTimeNow.Day - 1));
                for (int i = numberOfFirstDay - 1; i >= 0; i--)
                {
                    firstDayOfMonth = firstDayOfMonth.AddDays(-1);
                    tempType = CheckTypeFromDataBase(firstDayOfMonth);
                    monthView[i] = new DayModel(firstDayOfMonth, tempType);
                    monthView[i].ItsDayInCurrentMonth = false;
                }
            }
            Debug.Print("Model kalendarz utworzony");
            return monthView;
        }

        public static List<DayModel> GenerateWeekNameList(DayModel[] dayModels)
        {
            List<DayModel> weekDayNames = new List<DayModel>();

            for (int i = 0; i < 7; i++)
            {
                weekDayNames.Add(dayModels[i]);
            }

            return weekDayNames;
        }

        private static string CheckTypeFromDataBase(DateTime date)
        {

            List<EventModel> eventList = eventRepository.GetEventByData(date);
            if (eventList.Count > 0) 
            {
                return eventList[0].Type;
            }
            else
            {
                return "";
            }
        }

    }


}
