﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpellGenerator.Data;

#nullable disable

namespace SpellGenerator.Data.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240917122441_UpdateNullValuesForAddOn")]
    partial class UpdateNullValuesForAddOn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.33");

            modelBuilder.Entity("SpellAddOn", b =>
                {
                    b.Property<int>("AddOnId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpellId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AddOnId", "SpellId");

                    b.HasIndex("SpellId");

                    b.ToTable("SpellAddOn");
                });

            modelBuilder.Entity("SpellBookSpell", b =>
                {
                    b.Property<int>("SpellBookId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpellId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SpellBookId", "SpellId");

                    b.HasIndex("SpellId");

                    b.ToTable("SpellBookSpell");
                });

            modelBuilder.Entity("SpellGenerator.Data.DataModels.AddOn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("InstabilityValue")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ModifierValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("AddOns");
                });

            modelBuilder.Entity("SpellGenerator.Data.DataModels.Magic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Magics");
                });

            modelBuilder.Entity("SpellGenerator.Data.DataModels.Mastery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ParentMasteryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ParentMasteryId");

                    b.ToTable("Masteries");
                });

            modelBuilder.Entity("SpellGenerator.Data.DataModels.Spell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ManaCost")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Spells");
                });

            modelBuilder.Entity("SpellGenerator.Data.DataModels.SpellBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("SpellBooks");
                });

            modelBuilder.Entity("SpellGenerator.Data.DataModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpellBookId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SpellBookId")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("SpellMagics", b =>
                {
                    b.Property<int>("MagicId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpellId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MagicId", "SpellId");

                    b.HasIndex("SpellId");

                    b.ToTable("SpellMagics");
                });

            modelBuilder.Entity("SpellMasteries", b =>
                {
                    b.Property<int>("MasteryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpellId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MasteryId", "SpellId");

                    b.HasIndex("SpellId");

                    b.ToTable("SpellMasteries");
                });

            modelBuilder.Entity("UserMagics", b =>
                {
                    b.Property<int>("MagicId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MagicId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserMagics");
                });

            modelBuilder.Entity("UserMasteries", b =>
                {
                    b.Property<int>("MasteryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MasteryId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserMasteries");
                });

            modelBuilder.Entity("SpellAddOn", b =>
                {
                    b.HasOne("SpellGenerator.Data.DataModels.AddOn", null)
                        .WithMany()
                        .HasForeignKey("AddOnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpellGenerator.Data.DataModels.Spell", null)
                        .WithMany()
                        .HasForeignKey("SpellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SpellBookSpell", b =>
                {
                    b.HasOne("SpellGenerator.Data.DataModels.SpellBook", null)
                        .WithMany()
                        .HasForeignKey("SpellBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpellGenerator.Data.DataModels.Spell", null)
                        .WithMany()
                        .HasForeignKey("SpellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SpellGenerator.Data.DataModels.Mastery", b =>
                {
                    b.HasOne("SpellGenerator.Data.DataModels.Mastery", "ParentMastery")
                        .WithMany()
                        .HasForeignKey("ParentMasteryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentMastery");
                });

            modelBuilder.Entity("SpellGenerator.Data.DataModels.User", b =>
                {
                    b.HasOne("SpellGenerator.Data.DataModels.SpellBook", "SpellBook")
                        .WithOne("User")
                        .HasForeignKey("SpellGenerator.Data.DataModels.User", "SpellBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SpellBook");
                });

            modelBuilder.Entity("SpellMagics", b =>
                {
                    b.HasOne("SpellGenerator.Data.DataModels.Magic", null)
                        .WithMany()
                        .HasForeignKey("MagicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpellGenerator.Data.DataModels.Spell", null)
                        .WithMany()
                        .HasForeignKey("SpellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SpellMasteries", b =>
                {
                    b.HasOne("SpellGenerator.Data.DataModels.Mastery", null)
                        .WithMany()
                        .HasForeignKey("MasteryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpellGenerator.Data.DataModels.Spell", null)
                        .WithMany()
                        .HasForeignKey("SpellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserMagics", b =>
                {
                    b.HasOne("SpellGenerator.Data.DataModels.Magic", null)
                        .WithMany()
                        .HasForeignKey("MagicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpellGenerator.Data.DataModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserMasteries", b =>
                {
                    b.HasOne("SpellGenerator.Data.DataModels.Mastery", null)
                        .WithMany()
                        .HasForeignKey("MasteryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpellGenerator.Data.DataModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SpellGenerator.Data.DataModels.SpellBook", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
