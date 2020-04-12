using System;
using api.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityConfiguration
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.ToTable("lesson");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Description)
               .HasColumnName("description")
               .HasMaxLength(250)
               .IsRequired();

            builder.Property(p => p.InitialHour)
               .HasColumnName("startHour")
              
               .IsRequired(true);


            builder.Property(p => p.EndHour)
             .HasColumnName("endHour")
            
             .IsRequired(true);

            builder.Property(p => p.idTypeClass)
              .HasColumnName("idTypeClass")
              .IsRequired();

            builder.Property(p => p.idInstructor)
              .HasColumnName("idInstructor")
              .IsRequired();

            builder.Property(p => p.idDaysWeek)
             .HasColumnName("idDaysWeek")
             .IsRequired();

            builder.Property(p => p.idClassRoom)
             .HasColumnName("idClassRoom")
             .IsRequired();

            builder.Property(p => p.CreatedAt)
                .HasColumnName("createdAt")
                .HasColumnType("datetime")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.UpdatedAt)
                .HasColumnName("updatedAt")
                .HasColumnType("datetime")
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(p => p.DeletedAt)
                .HasColumnName("deletedAt")
                .HasColumnType("datetime")
                .IsRequired(false);

            builder
                .HasOne(e => e.classType)
                .WithMany(e => e.lessons)
                .HasForeignKey(e => e.idTypeClass);

            builder
                .HasOne(e => e.daysWeek)
                .WithMany(e => e.lessons)
                .HasForeignKey(e => e.idDaysWeek);

            builder
                .HasOne(e => e.classRoom)
                .WithMany(e => e.lessons)
                .HasForeignKey(e => e.idClassRoom);
            builder
               .HasOne(e => e.instructor)
               .WithMany(e => e.lessons)
               .HasForeignKey(e => e.idInstructor);

            builder
                .HasKey(p => p.Id);


            builder
                    .HasData(
                        new Lesson
                        {
                            Id=1,
                            Name="Ioga",
                            Description=" Aulas de Ioga",
                            InitialHour="07:00",
                            EndHour="08:00",
                            idTypeClass=3,
                            idInstructor=1,
                            idDaysWeek=3,
                            idClassRoom=2


                        },
                        new Lesson
                        {
                            Id = 2,
                            Name = "Karatê",
                            Description = " Aulas de Karatê",
                            InitialHour = "10:00",
                            EndHour = "11:00",
                            idTypeClass = 4,
                            idInstructor = 1,
                            idDaysWeek = 4,
                            idClassRoom = 1

                        },
                        new Lesson
                        {
                            Id = 3,
                            Name = "Natação",
                            Description = " Aulas de Natação",
                            InitialHour = "18:00",
                            EndHour = "19:00",
                            idTypeClass = 5,
                            idInstructor = 1,
                            idDaysWeek = 5,
                            idClassRoom = 3

                        },
                        new Lesson
                        {
                            Id = 4,
                            Name = "Musculação",
                            Description = " Aulas de Musculação",
                            InitialHour = "19:00",
                            EndHour = "20:00",
                            idTypeClass = 5,
                            idInstructor = 1,
                            idDaysWeek = 6,
                            idClassRoom = 2

                        }
                    );
        }
    }
}