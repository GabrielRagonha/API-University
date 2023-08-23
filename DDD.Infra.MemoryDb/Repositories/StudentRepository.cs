using DDD.Infra.MemoryDb.Interfaces;
using DDD.Unimar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.MemoryDb.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public StudentRepository()
        {
            using (var context = new ApiContext())
            {
                var students = new List<Student>()
                {
                    new Student
                    {
                        FirstName = "Gabriel",
                        LastName = "Rodrigues",
                        Email = "gabriel@hotmail.com",
                        IsActive = true,
                        RegisterDate = DateTime.Now,
                        Id = 1,
                        Disciplines = new List<Discipline>()
                        {
                            new Discipline ()
                            {
                                Id = 1,
                                Name = "Programação II",
                                EAD = true,
                                IsAvailable = true,
                                Value = 100.00
                            },

                            new Discipline ()
                            {
                                Id = 2,
                                Name = "Programação Web",
                                EAD = true,
                                IsAvailable = true,
                                Value = 100.00
                            },

                            new Discipline ()
                            {
                                Id = 3,
                                Name = "Banco de dados",
                                EAD = true,
                                IsAvailable = true,
                                Value = 50.00
                            }
                        }
                    },

                    new Student
                    {
                        FirstName = "Jeferson",
                        LastName = "Menezes",
                        Email = "jeff@hotmail.com",
                        IsActive = true,
                        RegisterDate = DateTime.Now,
                        Id = 2,
                        Disciplines = new List<Discipline>()
                        {
                            new Discipline ()
                            {
                                Id = 4,
                                Name = "Programação II",
                                EAD = true,
                                IsAvailable = true,
                                Value = 100.00
                            },

                            new Discipline ()
                            {
                                Id = 5,
                                Name = "Programação Web",
                                EAD = true,
                                IsAvailable = true,
                                Value = 100.00
                            },

                            new Discipline ()
                            {
                                Id = 6,
                                Name = "Banco de dados",
                                EAD = true,
                                IsAvailable = true,
                                Value = 50.00
                            }
                        }
                    }
                };

                context.Students.AddRange(students);
                context.SaveChanges();
            }
        }



        public List<Student> GetStudents()
        {
            using (var context = new ApiContext())
            {
                var list = context.Students.Include(x => x.Disciplines).ToList();
                return list;
            }
        }
    }
}
