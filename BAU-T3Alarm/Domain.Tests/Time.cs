using System;
using Xunit;

namespace Domain.Tests
{
    public class Time
    {
        [Fact]
        public void ding_in_office_hours_afternoon()
        {
            var now = DateTime.Parse("2009/02/26 15:37:58");
            var timer = new TimeToDing();
            var result = timer.CheckTime(now);
            Assert.True(result);
        }

        [Fact]
        public void ding_in_office_hours_morning()
        {
            var now = DateTime.Parse("2009/02/26 08:00:00");
            var timer = new TimeToDing();
            var result = timer.CheckTime(now);
            Assert.True(result);
        }

        [Fact]
        public void no_ding_outside_office_hours_evening()
        {
            var now = DateTime.Parse("2009/02/26 17:31:58");
            var timer = new TimeToDing();
            var result = timer.CheckTime(now);
            Assert.False(result);
        }

        [Fact]
        public void no_ding_in_outside_office_hours_morning()
        {
            var now = DateTime.Parse("2009/02/26 07:31:58");
            var timer = new TimeToDing();
            var result = timer.CheckTime(now);
            Assert.False(result);
        }

        [Fact]
        public void no_ding_at_the_weekend()
        {
            var now = DateTime.Parse("2015/09/19 09:59:58");
            var timer = new TimeToDing();
            var result = timer.CheckTime(now);
            Assert.False(result);
        }

        [Fact]
        public void no_ding_on_xmas_day()
        {
            var now = DateTime.Parse("2015/12/25 09:59:58");
            var timer = new TimeToDing();
            var result = timer.CheckTime(now);
            Assert.False(result);
        }

        [Fact]
        public void no_ding_on_boxing_day()
        {
            var now = DateTime.Parse("2015/12/26 09:59:58");
            var timer = new TimeToDing();
            var result = timer.CheckTime(now);
            Assert.False(result);
        }

        [Fact]
        public void no_ding_on_new_years_day()
        {
            var now = DateTime.Parse("2015/1/1 09:59:58");
            var timer = new TimeToDing();
            var result = timer.CheckTime(now);
            Assert.False(result);
        }
    }
}
