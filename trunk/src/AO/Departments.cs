namespace THS.UMS.AO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using THS.UMS.DTO;
    using THS.UMS.EF;

    public class Departments
    {
        /// <summary>
        /// Gets the active departments.
        /// </summary>
        /// <returns></returns>
        public List<DepartmentDTO> GetActiveDepartments()
        {
            using (var ctx = new AppEntities())
            {
                var r = new List<DepartmentDTO>();
                foreach (var d in ctx.Departments.Where(d => d.IsEnabled))
                {
                    r.Add(BuildDepartmentFromEntity(d));
                }
                return r.OrderBy(d => d.Name).ToList();
            }
        }

        /// <summary>
        /// Gets the department.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public DepartmentDTO GetDepartment(Guid key)
        {
            using (var ctx = new AppEntities())
            {
                return BuildDepartmentFromEntity(ctx.Departments.Where(d => d.DepartmentId == key).FirstOrDefault());
            }
        }

        /// <summary>
        /// Gets the name of the department by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public DepartmentDTO GetDepartmentByName(string name)
        {
            using (var ctx = new AppEntities())
            {
                var e = ctx.Departments.Where(d => d.Name == name && d.IsEnabled).FirstOrDefault();
                return e != null ? BuildDepartmentFromEntity(e) : null;
            }
        }

        /// <summary>
        /// Adds the department.
        /// </summary>
        /// <param name="dto">The department to add.</param>
        /// <returns></returns>
        public bool AddDepartment(DepartmentDTO dto)
        {
            using (var ctx = new AppEntities())
            {
                try
                {
                    var d = new Department()
                    {
                        IsEnabled = true,
                        DepartmentId = Guid.NewGuid(),
                        Name = dto.Name,
                        Description = dto.Description
                    };
                    ctx.Departments.AddObject(d);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Updates the department.
        /// </summary>
        /// <param name="dto">The department to update.</param>
        /// <returns></returns>
        public bool UpdateDepartment(DepartmentDTO dto)
        {
            using (var ctx = new AppEntities())
            {
                try
                {
                    var e = ctx.Departments.Where(d => d.DepartmentId == dto.DepartmentId).FirstOrDefault();
                    e.Name = dto.Name;
                    e.Description = dto.Description;
                    e.IsEnabled = dto.IsEnabled;

                    ctx.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Builds the department from entity.
        /// </summary>
        /// <param name="d">The department.</param>
        /// <returns></returns>
        private static DepartmentDTO BuildDepartmentFromEntity(Department d)
        {
            if (d != null)
                return new DepartmentDTO
                {
                    DepartmentId = d.DepartmentId,
                    Name = d.Name,
                    Description = d.Description,
                    IsEnabled = d.IsEnabled
                };
            return null;
        }
    }
}
