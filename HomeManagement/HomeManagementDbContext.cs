using Microsoft.EntityFrameworkCore;

namespace HomeManagement;

public class HomeManagementDbContext(DbContextOptions<HomeManagementDbContext> options) : DbContext(options)
{
    public DbSet<Device> Devices => Set<Device>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var device = modelBuilder.Entity<Device>();
        device.ToTable("Devices");
        device.HasKey(d => d.Name);
        device.Property(d => d.Name).HasMaxLength(100).IsRequired();
        device.Property(d => d.Ip).HasMaxLength(100).IsRequired();
<<<<<<< HEAD

=======
        device.Property(d => d.UptimeSeconds);

        // Configure owned collection of actions
>>>>>>> fbc592b (Refactor and enhance device management system)
        device.OwnsMany(d => d.Actions, a =>
        {
            a.WithOwner().HasForeignKey("DeviceName");
            a.ToTable("DeviceActions");
            a.Property(x => x.Action).HasMaxLength(50).IsRequired();
            a.Property(x => x.Command).IsRequired();
<<<<<<< HEAD

=======
            // Shadow key for owned entity instances
>>>>>>> fbc592b (Refactor and enhance device management system)
            a.Property<int>("Id").ValueGeneratedOnAdd();
            a.HasKey("Id");
        });
    }
}