using SCHOOL_PROJECT_INFRASTRUCTURE.Models;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Relationships.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.School.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Config;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.School.Interfaces;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.School
{
    public class SchoolUnitOfWork : BaseConfigUnitOfWork, ISchoolUnitOfWork
    {
        public SchoolUnitOfWork(ApplicationDbContext applicationDbContext, ISchoolRepository repo, ISchoolUserRelationshipRepository schoolUserRelationshipRepository, ISchoolTeacherRelationshipRepository schoolTeacherRelationship) : base(applicationDbContext)
        {
            SchoolRepository = repo;
            SchoolUserRelationshipRepository = schoolUserRelationshipRepository;
            SchoolTeacherRelationship = schoolTeacherRelationship;
        }


        public ISchoolRepository SchoolRepository { get; }
        public ISchoolUserRelationshipRepository SchoolUserRelationshipRepository { get; }
        public ISchoolTeacherRelationshipRepository SchoolTeacherRelationship { get; }
    }
}
