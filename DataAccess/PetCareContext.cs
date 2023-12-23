using Entity.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PetCareContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=petCareDB;Username=postgres;Password=1905");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Navigation(user => user.Pets).AutoInclude();
            modelBuilder.Entity<Food>().Navigation(food => food.Pet).AutoInclude();
            modelBuilder.Entity<Activity>().Navigation(activity => activity.Pet).AutoInclude();
            modelBuilder.Entity<HealthStatus>().Navigation(healthStatus => healthStatus.Pet).AutoInclude();

            modelBuilder.Entity<Pet>().Navigation(pet => pet.User).AutoInclude();
            modelBuilder.Entity<Pet>().Navigation(pet => pet.HealthStatus).AutoInclude();
            modelBuilder.Entity<Pet>().Navigation(pet => pet.Foods).AutoInclude();
            modelBuilder.Entity<Pet>().Navigation(pet => pet.Activities).AutoInclude();


            modelBuilder.Entity<Pet>()
                .HasOne(pet => pet.User)
                .WithMany(user => user.Pets)
                .HasForeignKey(pet => pet.UserId);

            modelBuilder.Entity<Pet>()
                .HasOne(pet => pet.HealthStatus)
                .WithOne(healthStatus => healthStatus.Pet)
                .HasForeignKey<HealthStatus>(healthStatus => healthStatus.PetId);

            modelBuilder.Entity<Pet>()
                .HasMany(pet => pet.Foods)
                .WithOne(food => food.Pet)
                .HasForeignKey(food => food.PetId);

            modelBuilder.Entity<Pet>()
                .HasMany(pet => pet.Activities)
                .WithOne(activity => activity.Pet)
                .HasForeignKey(activity => activity.PetId);



            modelBuilder.Entity<TrainingMapPet>()
            .HasKey(pt => new { pt.PetId, pt.TrainingId });

            modelBuilder.Entity<TrainingMapPet>()
                .HasOne(pt => pt.Pets)
                .WithMany(p => p.TrainingMapPets)
                .HasForeignKey(pt => pt.PetId);

            modelBuilder.Entity<TrainingMapPet>()
                .HasOne(pt => pt.Trainings)
                .WithMany(t => t.TrainingMapPets)
                .HasForeignKey(pt => pt.TrainingId);
        }


        public DbSet<TrainingMapPet> TrainingMapPets { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<HealthStatus> HealthStatuses { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<TrainingMapPet> TrainingsMapPets { get; set;}
        public DbSet<SocialInteraction> SocialInteraction { get; set; }
        public DbSet<SocialInteractionMapPet> SocialInteractionMapPets { get; set; }
    }
}
