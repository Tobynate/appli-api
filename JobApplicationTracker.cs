using System.ComponentModel.DataAnnotations;

namespace Appli.Api
{
    public class JobApplicationTracker
    {
        private readonly List<JobApplication> _applications = [];

        public IReadOnlyList<JobApplication> FetchApplications() => _applications;


        public void AddApplication(JobApplication application)
        {
            application.Id = Guid.NewGuid();
            var context = new ValidationContext(application);
            Validator.ValidateObject(application, context, validateAllProperties: true);
            _applications.Add(application);
        }

        public void RemoveApplication(Guid id)
        {
            _applications.RemoveAll(a => a.Id == id);
        }

        public void EditStatus(Guid id, JobApplicationStatus status)
        {
            var app = _applications.FirstOrDefault(a => a.Id == id) ?? throw new InvalidOperationException("Application not found.");
            app.Status = status;

        }
    }
}
