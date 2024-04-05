﻿using Domainify.Domain;
using MediatR;

namespace Domain.TaskAggregation
{
    public class AddNewTask
        : RequestToCreate<Task, string>
    {
        public string ProjectId { get; private set; }

        [BindTo(typeof(Task), nameof(Task.Description))]
        public string Description { get; private set; }

        public string? SprintId { get; private set; }
        public TaskStatus Status { get; private set; } = Task.GetTaskStatusDefaultValue();

        public AddNewTask(string projectId,
            string description, string? sprintId = null)
        {
            ProjectId = projectId;
            Description = description.Trim();
            SprintId = sprintId;

            ValidationState.Validate();
        }

        public override async Task<Task> ResolveAndGetEntityAsync(
            IMediator mediator)
        {
            await InvariantState.AssestAsync(mediator);

            var task = Task.New()
                .SetProjectId(ProjectId)
                .SetDescription(Description)
                .SetSprintId(SprintId)
                .SetStatus(Status);
            await base.ResolveAsync(mediator, task);
            return task;
        }
    }
}