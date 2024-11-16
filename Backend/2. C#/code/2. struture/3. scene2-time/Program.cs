// 使用场景2：处理日期时间范围（常用于预定、排版系统）
struct DateTimeRange
{
    public DateTime Start { get; }
    public DateTime End { get; }

    public DateTimeRange(DateTime start, DateTime end)
    {
        if(start > end)
        {
            throw new ArgumentException("结束时间不能早于开始时间");
        }

        Start = start;
        End = end;
    }

    //检查两个班次是否有重叠
    public bool Overlaps(DateTimeRange other)
    {
        return Start < other.End && End > other.Start;
    }
}