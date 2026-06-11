namespace Appli.Api.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly List<JobApplication> _applications = new List<JobApplication>
        {
            new JobApplication
            {
                Id = Guid.NewGuid(),
                Company = "Google",
                Role = "Software Engineer",
                Link = "https://careers.google.com/jobs/results/123456-software-engineer/",
                Status = JobApplicationStatus.Applied

            },
            new JobApplication
            {
                Id = Guid.NewGuid(),
                Company = "Microsoft",
                Role = "Program Manager",
                Link = "https://careers.microsoft.com/us/en/job/123456/Program-Manager",
                Status = JobApplicationStatus.Interviewing
            }
        };
        public JobApplication Add(JobApplication application)
        {
            application.Id = Guid.NewGuid();
            _applications.Add(application);

            return application;
        }

        public bool Delete(Guid id) => _applications.RemoveAll(a => a.Id == id) > 0;

        public IEnumerable<JobApplication> GetAll() => _applications;
        public JobApplication? GetById(Guid id) => _applications.FirstOrDefault(a => a.Id == id);

        public bool Update(Guid id, JobApplication updatedApplication)
        {
            JobApplication? existingApplication = GetById(id);
            if (existingApplication is null) return false;
            existingApplication.Company = updatedApplication.Company;
            existingApplication.Role = updatedApplication.Role;
            existingApplication.Link = updatedApplication.Link;
            existingApplication.Status = updatedApplication.Status;
            
            return true;
        }

        public bool UpdateStatus(Guid id, JobApplicationStatus status)
        {
            JobApplication? existingApplication = GetById(id);
            if(existingApplication is null) return false;
            existingApplication.Status = status;
            return true;
        }
    }
}
