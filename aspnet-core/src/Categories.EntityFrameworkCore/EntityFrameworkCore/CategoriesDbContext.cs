using Categories.Departments;
using Categories.ExpenseCodes;
using Categories.KindOfFALs;
using Categories.LegalEntitys;

using Categories.VATs;
using Categories.Currencys;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Categories.Suppliers;
using Categories.Trips;
using Categories.TripExpenses;

namespace Categories.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class CategoriesDbContext :
    AbpDbContext<CategoriesDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<Department> Departments { get; set; }
    public DbSet<LegalEntity> LegalEntities { get; set; }
    public DbSet<VAT> VATs { get; set; }
    public DbSet<KindOfFAL> KindOfFals { get; set; }
    public DbSet<ExpenseCode> ExpenseCodes { get; set; }
    public DbSet<Currency> Currencys { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<TripExpense> TripExpenses { get; set; }


    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion
    public CategoriesDbContext(DbContextOptions<CategoriesDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(CategoriesConsts.DbTablePrefix + "YourEntities", CategoriesConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
        builder.Entity<LegalEntity>(b =>
        {
            b.ToTable(CategoriesConsts.DbTablePrefix + "LegalEntitys", CategoriesConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Code).IsRequired().HasMaxLength(128);
            b.Property(x => x.Description).IsRequired().HasMaxLength(128);
            b.Property(x => x.ImportBy).IsRequired().HasMaxLength(128);
        });
        builder.Entity<Department>(b =>
        {
            b.ToTable(CategoriesConsts.DbTablePrefix + "Departments", CategoriesConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Code).IsRequired().HasMaxLength(128);
            b.Property(x => x.Description).IsRequired().HasMaxLength(128);
            b.Property(x => x.ImportBy).IsRequired().HasMaxLength(128);
        });
        builder.Entity<Currency>(b =>
        {
            b.ToTable(CategoriesConsts.DbTablePrefix + "Currencys", CategoriesConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Code).IsRequired().HasMaxLength(128);
        });
        builder.Entity<KindOfFAL>(b =>
        {
            b.ToTable(CategoriesConsts.DbTablePrefix + "KindOfFals", CategoriesConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.KindOfFal).IsRequired().HasMaxLength(128);

        });
        builder.Entity<VAT>(b =>
        {
            b.ToTable(CategoriesConsts.DbTablePrefix + "VATs", CategoriesConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.VATs).IsRequired().HasMaxLength(128);
            b.Property(x => x.VATAxCode).IsRequired().HasMaxLength(128);
            b.Property(x => x.Description).IsRequired().HasMaxLength(128);


        });
        builder.Entity<ExpenseCode>(b =>
        {
            b.ToTable(CategoriesConsts.DbTablePrefix + "ExpenseCodes", CategoriesConsts.DbSchema);
            b.ConfigureByConvention();

        });
        builder.Entity<Supplier>(b =>
        {
            b.ToTable(CategoriesConsts.DbTablePrefix + "Suppliers", CategoriesConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne<LegalEntity>().WithMany().HasForeignKey(x => x.LegalID).IsRequired();
        });
        builder.Entity<Trip>(b =>
        {
            b.ToTable(CategoriesConsts.DbTablePrefix + "Trips", CategoriesConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne<LegalEntity>().WithMany().HasForeignKey(x => x.LegalID).IsRequired();
            b.HasOne<Department>().WithMany().HasForeignKey(x => x.DepartmentID).IsRequired();
            b.HasOne<ExpenseCode>().WithMany().HasForeignKey(x => x.ExpenseCodeID).IsRequired();
            
        });
        builder.Entity<TripExpense>(b =>
        {
            b.ToTable(CategoriesConsts.DbTablePrefix + "TripExpenses", CategoriesConsts.DbSchema);
            b.ConfigureByConvention();
        });
        
    }
}
