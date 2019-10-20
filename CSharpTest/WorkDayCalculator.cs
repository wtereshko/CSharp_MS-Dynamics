using System;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            if (dayCount == 0)
            {
                return startDate;
            }

            if (weekEnds == null)
            {
                return startDate.AddDays(dayCount - 1);
            }

            DateTime resultDate = startDate.AddDays(dayCount);

            for (int i = 0; i < weekEnds.Length; i++)
            {
                if (resultDate >= weekEnds[i].StartDate)
                {
                    TimeSpan span = weekEnds[i].EndDate.Subtract(weekEnds[i].StartDate);

                    if (i != 0)
                    {
                        resultDate = resultDate.AddDays(span.TotalDays + 1);
                    }
                    else
                    {
                        resultDate = resultDate.AddDays(span.TotalDays);
                    }

                }
            }
            return resultDate;
        }
    }
}
