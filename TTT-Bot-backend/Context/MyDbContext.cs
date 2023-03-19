using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TTT_Bot_backend.Entities;

namespace TTT_Bot_backend.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activexpboost> Activexpboosts { get; set; }

    public virtual DbSet<Botstat> Botstats { get; set; }

    public virtual DbSet<Catvsdog> Catvsdogs { get; set; }

    public virtual DbSet<Garden> Gardens { get; set; }

    public virtual DbSet<GardenHasGardenplot> GardenHasGardenplots { get; set; }

    public virtual DbSet<Gardenplot> Gardenplots { get; set; }

    public virtual DbSet<Guild> Guilds { get; set; }

    public virtual DbSet<GuildHasUser> GuildHasUsers { get; set; }

    public virtual DbSet<GuildHasUserHasRole> GuildHasUserHasRoles { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemHasInventory> ItemHasInventories { get; set; }

    public virtual DbSet<Lottery> Lotteries { get; set; }

    public virtual DbSet<LotteryHasLotteryparticipant> LotteryHasLotteryparticipants { get; set; }

    public virtual DbSet<Lotteryparticipant> Lotteryparticipants { get; set; }

    public virtual DbSet<Marriage> Marriages { get; set; }

    public virtual DbSet<Marriagejoinrequest> Marriagejoinrequests { get; set; }

    public virtual DbSet<MarriagejoinrequestHasUserHasMarriage> MarriagejoinrequestHasUserHasMarriages { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<NotificationsHasUser> NotificationsHasUsers { get; set; }

    public virtual DbSet<Plant> Plants { get; set; }

    public virtual DbSet<Planttype> Planttypes { get; set; }

    public virtual DbSet<PlanttypeHasPlantyield> PlanttypeHasPlantyields { get; set; }

    public virtual DbSet<Plantyield> Plantyields { get; set; }

    public virtual DbSet<Pokemon> Pokemons { get; set; }

    public virtual DbSet<PokemonEvolution> PokemonEvolutions { get; set; }

    public virtual DbSet<PokemonEvolutionGroup> PokemonEvolutionGroups { get; set; }

    public virtual DbSet<PokemonEvolutionGroupHasPokemonEvolution> PokemonEvolutionGroupHasPokemonEvolutions { get; set; }

    public virtual DbSet<Pokemontype> Pokemontypes { get; set; }

    public virtual DbSet<PokemontypeIsStrongAgainstPokemontype> PokemontypeIsStrongAgainstPokemontypes { get; set; }

    public virtual DbSet<PokemontypeIsWeakAgainstPokemontype> PokemontypeIsWeakAgainstPokemontypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<Statistic> Statistics { get; set; }

    public virtual DbSet<Upgradesstatus> Upgradesstatuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserHasActivexpboost> UserHasActivexpboosts { get; set; }

    public virtual DbSet<UserHasMarriage> UserHasMarriages { get; set; }

    public virtual DbSet<UserHasMarriageMustProcessMarriagejoinrequest> UserHasMarriageMustProcessMarriagejoinrequests { get; set; }

    public virtual DbSet<UserHasPokemon> UserHasPokemons { get; set; }

    public virtual DbSet<UserHasPokemonFightRequest> UserHasPokemonFightRequests { get; set; }

    public virtual DbSet<UserMarriageProposal> UserMarriageProposals { get; set; }

    public virtual DbSet<Xpboost> Xpboosts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=ttt-bot;user=root;password=sml12345", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Activexpboost>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.XpBoostId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("activexpboost");

            entity.HasIndex(e => e.XpBoostId, "fk_ActiveXpBoost_XpBoost1_idx");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.EndTime).HasColumnType("datetime");

            entity.HasOne(d => d.XpBoost).WithMany(p => p.Activexpboosts)
                .HasForeignKey(d => d.XpBoostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ActiveXpBoost_XpBoost1");
        });

        modelBuilder.Entity<Botstat>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("botstats");
        });

        modelBuilder.Entity<Catvsdog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("catvsdog");

            entity.Property(e => e.Cat).HasColumnName("cat");
            entity.Property(e => e.Dog).HasColumnName("dog");
        });

        modelBuilder.Entity<Garden>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("garden");
        });

        modelBuilder.Entity<GardenHasGardenplot>(entity =>
        {
            entity.HasKey(e => new { e.GardenId, e.GardenPlotId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("garden_has_gardenplot");

            entity.HasIndex(e => e.GardenId, "fk_Garden_has_GardenPlot_Garden1_idx");

            entity.HasIndex(e => e.GardenPlotId, "fk_Garden_has_GardenPlot_GardenPlot1_idx");

            entity.HasOne(d => d.Garden).WithMany(p => p.GardenHasGardenplots)
                .HasForeignKey(d => d.GardenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Garden_has_GardenPlot_Garden1");
        });

        modelBuilder.Entity<Gardenplot>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.PlantId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("gardenplot");

            entity.HasIndex(e => e.PlantId, "fk_GardenPlot_Plant1_idx");
        });

        modelBuilder.Entity<Guild>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.CatVsDogId, e.LotteryId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("guild");

            entity.HasIndex(e => e.LotteryId, "fk_Guild_Lottery1_idx");

            entity.HasIndex(e => e.CatVsDogId, "fk_Guild_catvsdog_idx");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.CatVsDog).WithMany(p => p.Guilds)
                .HasForeignKey(d => d.CatVsDogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Guild_catvsdog");

            entity.HasOne(d => d.Lottery).WithMany(p => p.Guilds)
                .HasForeignKey(d => d.LotteryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Guild_Lottery1");
        });

        modelBuilder.Entity<GuildHasUser>(entity =>
        {
            entity.HasKey(e => new { e.GuildId, e.UserId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("guild_has_user");

            entity.HasIndex(e => e.GuildId, "fk_Guild_has_User_Guild1_idx");

            entity.HasIndex(e => e.UserId, "fk_Guild_has_User_User1_idx");

            entity.Property(e => e.NickName).HasColumnType("text");
        });

        modelBuilder.Entity<GuildHasUserHasRole>(entity =>
        {
            entity.HasKey(e => new { e.GuildHasUserUserId, e.RoleId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("guild_has_user_has_role");

            entity.HasIndex(e => e.GuildHasUserUserId, "fk_Guild_has_User_has_Role_Guild_has_User1_idx");

            entity.HasIndex(e => e.RoleId, "fk_Guild_has_User_has_Role_Role1_idx");

            entity.HasOne(d => d.Role).WithMany(p => p.GuildHasUserHasRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Guild_has_User_has_Role_Role1");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("inventory");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("item");

            entity.Property(e => e.Name).HasColumnType("text");
        });

        modelBuilder.Entity<ItemHasInventory>(entity =>
        {
            entity.HasKey(e => new { e.ItemId, e.InventoryId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("item_has_inventory");

            entity.HasIndex(e => e.InventoryId, "fk_Item_has_Inventory_Inventory1_idx");

            entity.HasIndex(e => e.ItemId, "fk_Item_has_Inventory_Item1_idx");

            entity.Property(e => e.Count).HasColumnName("count");

            entity.HasOne(d => d.Inventory).WithMany(p => p.ItemHasInventories)
                .HasForeignKey(d => d.InventoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Item_has_Inventory_Inventory1");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemHasInventories)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Item_has_Inventory_Item1");
        });

        modelBuilder.Entity<Lottery>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("lottery");

            entity.Property(e => e.EndTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<LotteryHasLotteryparticipant>(entity =>
        {
            entity.HasKey(e => new { e.LotteryId, e.LotteryParticipantId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("lottery_has_lotteryparticipant");

            entity.HasIndex(e => e.LotteryId, "fk_Lottery_has_LotteryParticipant_Lottery1_idx");

            entity.HasIndex(e => e.LotteryParticipantId, "fk_Lottery_has_LotteryParticipant_LotteryParticipant1_idx");

            entity.HasOne(d => d.Lottery).WithMany(p => p.LotteryHasLotteryparticipants)
                .HasForeignKey(d => d.LotteryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Lottery_has_LotteryParticipant_Lottery1");
        });

        modelBuilder.Entity<Lotteryparticipant>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.UserId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("lotteryparticipant");

            entity.HasIndex(e => e.UserId, "fk_LotteryParticipant_User1_idx");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Marriage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("marriage");

            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("StartTIme");
        });

        modelBuilder.Entity<Marriagejoinrequest>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.UserId, e.MarriageId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("marriagejoinrequest");

            entity.HasIndex(e => e.MarriageId, "fk_MarrigaeJoinRequest_Marriage1_idx");

            entity.HasIndex(e => e.UserId, "fk_MarrigaeJoinRequest_User1_idx");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Marriage).WithMany(p => p.Marriagejoinrequests)
                .HasForeignKey(d => d.MarriageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MarrigaeJoinRequest_Marriage1");
        });

        modelBuilder.Entity<MarriagejoinrequestHasUserHasMarriage>(entity =>
        {
            entity.HasKey(e => new { e.MarriageJoinRequestId, e.UserHasMarriageUserId, e.UserHasMarriageMarriageId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("marriagejoinrequest_has_user_has_marriage");

            entity.HasIndex(e => e.MarriageJoinRequestId, "fk_MarrigaeJoinRequest_has_User_Has_Marriage_MarrigaeJoinRe_idx");

            entity.HasIndex(e => new { e.UserHasMarriageUserId, e.UserHasMarriageMarriageId }, "fk_MarrigaeJoinRequest_has_User_Has_Marriage_User_Has_Marri_idx");

            entity.HasOne(d => d.UserHasMarriage).WithMany(p => p.MarriagejoinrequestHasUserHasMarriages)
                .HasForeignKey(d => new { d.UserHasMarriageUserId, d.UserHasMarriageMarriageId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MarrigaeJoinRequest_has_User_Has_Marriage_User_Has_Marriage1");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("notifications");

            entity.Property(e => e.Message).HasColumnType("text");
            entity.Property(e => e.NotifyTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<NotificationsHasUser>(entity =>
        {
            entity.HasKey(e => new { e.NotificationsId, e.UserId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("notifications_has_user");

            entity.HasIndex(e => e.NotificationsId, "fk_Notifications_has_User_Notifications1_idx");

            entity.HasIndex(e => e.UserId, "fk_Notifications_has_User_User1_idx");

            entity.HasOne(d => d.Notifications).WithMany(p => p.NotificationsHasUsers)
                .HasForeignKey(d => d.NotificationsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Notifications_has_User_Notifications1");
        });

        modelBuilder.Entity<Plant>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.PlantTypeId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("plant");

            entity.HasIndex(e => e.PlantTypeId, "fk_Plant_PlantType1_idx");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.PlantedTime).HasColumnType("datetime");

            entity.HasOne(d => d.PlantType).WithMany(p => p.Plants)
                .HasForeignKey(d => d.PlantTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Plant_PlantType1");
        });

        modelBuilder.Entity<Planttype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("planttype");

            entity.Property(e => e.Name).HasColumnType("text");
            entity.Property(e => e.TimeToGrow).HasColumnType("time");
        });

        modelBuilder.Entity<PlanttypeHasPlantyield>(entity =>
        {
            entity.HasKey(e => new { e.PlantTypeId, e.PlantYieldId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("planttype_has_plantyield");

            entity.HasIndex(e => e.PlantTypeId, "fk_PlantType_has_PlantYield_PlantType1_idx");

            entity.HasIndex(e => e.PlantYieldId, "fk_PlantType_has_PlantYield_PlantYield1_idx");

            entity.HasOne(d => d.PlantType).WithMany(p => p.PlanttypeHasPlantyields)
                .HasForeignKey(d => d.PlantTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_PlantType_has_PlantYield_PlantType1");
        });

        modelBuilder.Entity<Plantyield>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.ItemId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("plantyield");

            entity.HasIndex(e => e.ItemId, "fk_PlantYield_Item1_idx");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Item).WithMany(p => p.Plantyields)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_PlantYield_Item1");
        });

        modelBuilder.Entity<Pokemon>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.PokemonEvolutionGroupId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("pokemon");

            entity.HasIndex(e => e.PokemonEvolutionGroupId, "fk_Pokemon_Pokemon_Evolution_Group1_idx");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.AttackIv).HasColumnName("AttackIV");
            entity.Property(e => e.CooldownEndTime).HasColumnType("datetime");
            entity.Property(e => e.DefenseIv).HasColumnName("DefenseIV");
            entity.Property(e => e.HpIv).HasColumnName("HpIV");
            entity.Property(e => e.SpAttackIv).HasColumnName("SpAttackIV");
            entity.Property(e => e.SpDefenseIv).HasColumnName("SpDefenseIV");
            entity.Property(e => e.SpeedIv).HasColumnName("SpeedIV");

            entity.HasOne(d => d.PokemonEvolutionGroup).WithMany(p => p.Pokemons)
                .HasForeignKey(d => d.PokemonEvolutionGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Pokemon_Pokemon_Evolution_Group1");
        });

        modelBuilder.Entity<PokemonEvolution>(entity =>
        {
            entity.HasKey(e => e.PokedexId).HasName("PRIMARY");

            entity.ToTable("pokemon_evolution");

            entity.Property(e => e.PokedexId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasColumnType("text");

            entity.HasMany(d => d.PokemonTypes).WithMany(p => p.PokemonPokedices)
                .UsingEntity<Dictionary<string, object>>(
                    "PokemonHasPokemontype",
                    r => r.HasOne<Pokemontype>().WithMany()
                        .HasForeignKey("PokemonTypeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Pokemon_has_PokemonType_PokemonType1"),
                    l => l.HasOne<PokemonEvolution>().WithMany()
                        .HasForeignKey("PokemonPokedexId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Pokemon_has_PokemonType_Pokemon1"),
                    j =>
                    {
                        j.HasKey("PokemonPokedexId", "PokemonTypeId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("pokemon_has_pokemontype");
                        j.HasIndex(new[] { "PokemonPokedexId" }, "fk_Pokemon_has_PokemonType_Pokemon1_idx");
                        j.HasIndex(new[] { "PokemonTypeId" }, "fk_Pokemon_has_PokemonType_PokemonType1_idx");
                    });
        });

        modelBuilder.Entity<PokemonEvolutionGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pokemon_evolution_group");
        });

        modelBuilder.Entity<PokemonEvolutionGroupHasPokemonEvolution>(entity =>
        {
            entity.HasKey(e => new { e.PokemonEvolutionGroupId, e.PokemonEvolutionPokedexId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("pokemon_evolution_group_has_pokemon_evolution");

            entity.HasIndex(e => e.PokemonEvolutionPokedexId, "fk_Pokemon_Evolution_Group_has_Pokemon_Evolution_Pokemon_Ev_idx");

            entity.HasIndex(e => e.PokemonEvolutionGroupId, "fk_Pokemon_Evolution_Group_has_Pokemon_Evolution_Pokemon_Ev_idx1");

            entity.HasOne(d => d.PokemonEvolutionGroup).WithMany(p => p.PokemonEvolutionGroupHasPokemonEvolutions)
                .HasForeignKey(d => d.PokemonEvolutionGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Pokemon_Evolution_Group_has_Pokemon_Evolution_Pokemon_Evol1");

            entity.HasOne(d => d.PokemonEvolutionPokedex).WithMany(p => p.PokemonEvolutionGroupHasPokemonEvolutions)
                .HasForeignKey(d => d.PokemonEvolutionPokedexId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Pokemon_Evolution_Group_has_Pokemon_Evolution_Pokemon_Evol2");
        });

        modelBuilder.Entity<Pokemontype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pokemontype");

            entity.Property(e => e.Name).HasColumnType("text");
        });

        modelBuilder.Entity<PokemontypeIsStrongAgainstPokemontype>(entity =>
        {
            entity.HasKey(e => new { e.PokemonTypeId, e.StrongAgainstPokemonTypeId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("pokemontype_is_strong_against_pokemontype");

            entity.HasIndex(e => e.PokemonTypeId, "fk_PokemonType_has_PokemonType_PokemonType3_idx");

            entity.HasIndex(e => e.StrongAgainstPokemonTypeId, "fk_PokemonType_has_PokemonType_PokemonType4_idx");

            entity.HasOne(d => d.PokemonType).WithMany(p => p.PokemontypeIsStrongAgainstPokemontypePokemonTypes)
                .HasForeignKey(d => d.PokemonTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_PokemonType_has_PokemonType_PokemonType3");

            entity.HasOne(d => d.StrongAgainstPokemonType).WithMany(p => p.PokemontypeIsStrongAgainstPokemontypeStrongAgainstPokemonTypes)
                .HasForeignKey(d => d.StrongAgainstPokemonTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_PokemonType_has_PokemonType_PokemonType4");
        });

        modelBuilder.Entity<PokemontypeIsWeakAgainstPokemontype>(entity =>
        {
            entity.HasKey(e => new { e.PokemonTypeId, e.WeakAgainstPokemonTypeId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("pokemontype_is_weak_against_pokemontype");

            entity.HasIndex(e => e.PokemonTypeId, "fk_PokemonType_has_PokemonType_PokemonType1_idx");

            entity.HasIndex(e => e.WeakAgainstPokemonTypeId, "fk_PokemonType_has_PokemonType_PokemonType2_idx");

            entity.HasOne(d => d.PokemonType).WithMany(p => p.PokemontypeIsWeakAgainstPokemontypePokemonTypes)
                .HasForeignKey(d => d.PokemonTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_PokemonType_has_PokemonType_PokemonType1");

            entity.HasOne(d => d.WeakAgainstPokemonType).WithMany(p => p.PokemontypeIsWeakAgainstPokemontypeWeakAgainstPokemonTypes)
                .HasForeignKey(d => d.WeakAgainstPokemonTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_PokemonType_has_PokemonType_PokemonType2");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("role");

            entity.Property(e => e.Name).HasColumnType("text");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("settings");
        });

        modelBuilder.Entity<Statistic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("statistics");
        });

        modelBuilder.Entity<Upgradesstatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("upgradesstatus");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.SettingsId, e.StatisticsId, e.InventoryId, e.UpgradesStatusId, e.GardenId, e.AvtivePokemonId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0, 0, 0, 0 });

            entity.ToTable("user");

            entity.HasIndex(e => e.GardenId, "fk_User_Garden1_idx");

            entity.HasIndex(e => e.InventoryId, "fk_User_Inventory1_idx");

            entity.HasIndex(e => e.SettingsId, "fk_User_Settings1_idx");

            entity.HasIndex(e => e.StatisticsId, "fk_User_Statistics1_idx");

            entity.HasIndex(e => e.UpgradesStatusId, "fk_User_UpgradesStatus1_idx");

            entity.HasIndex(e => e.AvtivePokemonId, "fk_User_User_has_Pokemon1_idx");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Currency).HasColumnName("currency");
            entity.Property(e => e.LastDailyClaim).HasColumnType("datetime");
            entity.Property(e => e.LastWeeklyClaim).HasColumnType("datetime");

            entity.HasOne(d => d.Garden).WithMany(p => p.Users)
                .HasForeignKey(d => d.GardenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_User_Garden1");

            entity.HasOne(d => d.Inventory).WithMany(p => p.Users)
                .HasForeignKey(d => d.InventoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_User_Inventory1");

            entity.HasOne(d => d.Settings).WithMany(p => p.Users)
                .HasForeignKey(d => d.SettingsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_User_Settings1");

            entity.HasOne(d => d.Statistics).WithMany(p => p.Users)
                .HasForeignKey(d => d.StatisticsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_User_Statistics1");

            entity.HasOne(d => d.UpgradesStatus).WithMany(p => p.Users)
                .HasForeignKey(d => d.UpgradesStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_User_UpgradesStatus1");
        });

        modelBuilder.Entity<UserHasActivexpboost>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.ActiveXpBoostId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("user_has_activexpboost");

            entity.HasIndex(e => e.ActiveXpBoostId, "fk_User_has_ActiveXpBoost_ActiveXpBoost1_idx");

            entity.HasIndex(e => e.UserId, "fk_User_has_ActiveXpBoost_User1_idx");
        });

        modelBuilder.Entity<UserHasMarriage>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.MarriageId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("user_has_marriage");

            entity.HasIndex(e => e.MarriageId, "fk_User_has_Marriage_Marriage1_idx");

            entity.HasIndex(e => e.UserId, "fk_User_has_Marriage_User1_idx");

            entity.Property(e => e.JoinTime).HasColumnType("datetime");

            entity.HasOne(d => d.Marriage).WithMany(p => p.UserHasMarriages)
                .HasForeignKey(d => d.MarriageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_User_has_Marriage_Marriage1");
        });

        modelBuilder.Entity<UserHasMarriageMustProcessMarriagejoinrequest>(entity =>
        {
            entity.HasKey(e => new { e.MarriageHasMarriageJoinRequestId, e.UserHasMarriageUserId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("user_has_marriage_must_process_marriagejoinrequest");

            entity.HasIndex(e => e.UserHasMarriageUserId, "fk_Marriage_has_MarrigaeJoinRequest_has_User_has_Marriage_U_idx");
        });

        modelBuilder.Entity<UserHasPokemon>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.UserId, e.PokemonId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("user_has_pokemon");

            entity.HasIndex(e => e.PokemonId, "fk_User_has_Pokemon_Pokemon1_idx");

            entity.HasIndex(e => e.UserId, "fk_User_has_Pokemon_User1_idx");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<UserHasPokemonFightRequest>(entity =>
        {
            entity.HasKey(e => new { e.UserHasPokemonId, e.ChallengedUserHasPokemonId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("user_has_pokemon_fight_request");

            entity.HasIndex(e => e.UserHasPokemonId, "fk_User_Has_Pokemon_has_User_Has_Pokemon_User_Has_Pokemon1_idx");

            entity.HasIndex(e => e.ChallengedUserHasPokemonId, "fk_User_Has_Pokemon_has_User_Has_Pokemon_User_Has_Pokemon2_idx");

            entity.Property(e => e.UserHasPokemonId).HasColumnName("User_Has_Pokemon_Id");
            entity.Property(e => e.ChallengedUserHasPokemonId).HasColumnName("Challenged_User_Has_Pokemon_Id");
        });

        modelBuilder.Entity<UserMarriageProposal>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.UserId, e.ProposalMadeToUserId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("user_marriage_proposal");

            entity.HasIndex(e => e.UserId, "fk_User_has_User_User1_idx");

            entity.HasIndex(e => e.ProposalMadeToUserId, "fk_User_has_User_User2_idx");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Xpboost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("xpboost");

            entity.Property(e => e.Duration).HasColumnType("time");
            entity.Property(e => e.Multiplier).HasColumnName("multiplier");
            entity.Property(e => e.Name).HasColumnType("text");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
