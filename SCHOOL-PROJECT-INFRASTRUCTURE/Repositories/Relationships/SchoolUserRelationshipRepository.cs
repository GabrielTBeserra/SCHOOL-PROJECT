using SCHOOL_PROJECT_DOMAIN.Relationships.SchoolUser;
using SCHOOL_PROJECT_INFRASTRUCTURE.Models;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Config;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Config.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Relationships.Interfaces;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Relationships
{
    public class SchoolUserRelationshipRepository : GenericRepository<SchoolUserRelationship>, ISchoolUserRelationshipRepository
    {
        public SchoolUserRelationshipRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
