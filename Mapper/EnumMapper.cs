namespace tasks.Mapper
{
    public static class EnumMappers
    {
        public static Entity.ETaskPriority ToEntityETaskPriority(this Model.ETaskPriorityModel? priority)
        {
            return priority switch
            {
                Model.ETaskPriorityModel.High => Entity.ETaskPriority.High,
                Model.ETaskPriorityModel.Mid => Entity.ETaskPriority.Mid,
                Model.ETaskPriorityModel.Low => Entity.ETaskPriority.Low,
                _ => Entity.ETaskPriority.None,
            };
        }

        public static Entity.ETaskStatus ToEntityETaskStatus(this Model.ETaskStatusModel? status)
        {
            return status switch
            {
                Model.ETaskStatusModel.Completed => Entity.ETaskStatus.Completed,
                Model.ETaskStatusModel.InProgress => Entity.ETaskStatus.InProgress,
                Model.ETaskStatusModel.Postponed => Entity.ETaskStatus.Postponed,
                _ => Entity.ETaskStatus.None,
            };
        }

        public static Entity.ETaskRepeat ToEntityETaskRepeat(this Model.ETaskRepeatModel? repeat)
        {
            return repeat switch
            {
                Model.ETaskRepeatModel.Daily => Entity.ETaskRepeat.Daily,
                Model.ETaskRepeatModel.Hourly => Entity.ETaskRepeat.Hourly,
                Model.ETaskRepeatModel.Monthly => Entity.ETaskRepeat.Monthly,
                Model.ETaskRepeatModel.Weekly => Entity.ETaskRepeat.Weekly,
                Model.ETaskRepeatModel.Yearly => Entity.ETaskRepeat.Yearly,
                _ => Entity.ETaskRepeat.Never
            };
        }
    }
}