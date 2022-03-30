using SCHOOL_PROJECT_DOMAIN.Relationships.SchoolTeacher;
using SCHOOL_PROJECT_INFRASTRUCTURE.Models;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Config;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Relationships.Interfaces;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Relationships
{
    public class SchoolTeacherRelationshipRepository : GenericRepository<SchoolTeacherRelationship>, ISchoolTeacherRelationshipRepository
    {
        public SchoolTeacherRelationshipRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
