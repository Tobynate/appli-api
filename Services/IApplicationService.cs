namespace Appli.Api.Services
{
    public interface IApplicationService
    {
        IEnumerable<JobApplication> GetAll();
        JobApplication? GetById(Guid id);
        JobApplication Add(JobApplication application);
        bool Update(Guid id, JobApplication updatedapplication);
        bool UpdateStatus(Guid id, JobApplicationStatus status);
        bool Delete(Guid id);
    }
}
