﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UserRegister.Data;

#nullable disable

namespace UserRegister.Data.Migrations
{
    [DbContext(typeof(SqlContext))]
    [Migration("20220904224608_FixRelacionShipUserAddress")]
    partial class FixRelacionShipUserAddress
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence("AddressSequence");

            modelBuilder.HasSequence("UserPhoneSequence");

            modelBuilder.HasSequence("UserSequence");

            modelBuilder.Entity("UserRegister.Business.EntityModels.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("city")
                        .HasColumnOrder(6);

                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("code")
                        .HasColumnOrder(1)
                        .HasDefaultValueSql("nextval('\"AddressSequence\"')");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasColumnOrder(2);

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("district")
                        .HasColumnOrder(5);

                    b.Property<string>("Number")
                        .HasColumnType("text")
                        .HasColumnName("number");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("postal_code")
                        .HasColumnOrder(4);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("state")
                        .HasColumnOrder(7);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("street")
                        .HasColumnOrder(3);

                    b.HasKey("Id")
                        .HasName("pk_address");

                    b.ToTable("address", (string)null);
                });

            modelBuilder.Entity("UserRegister.Business.EntityModels.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uuid")
                        .HasColumnName("address_id")
                        .HasColumnOrder(8);

                    b.Property<string>("Cnpj")
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)")
                        .HasColumnName("cnpj")
                        .HasColumnOrder(6);

                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("code")
                        .HasColumnOrder(1)
                        .HasDefaultValueSql("nextval('\"UserSequence\"')");

                    b.Property<string>("CorporateName")
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)")
                        .HasColumnName("corporate_name")
                        .HasColumnOrder(7);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("cpf")
                        .HasColumnOrder(5);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasColumnOrder(2);

                    b.Property<bool>("LegalPerson")
                        .HasColumnType("boolean")
                        .HasColumnName("legal_person")
                        .HasColumnOrder(4);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name")
                        .HasColumnOrder(3);

                    b.HasKey("Id")
                        .HasName("pk_user");

                    b.HasIndex("AddressId")
                        .IsUnique()
                        .HasDatabaseName("ix_user_address_id");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("UserRegister.Business.EntityModels.UserPhone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("code")
                        .HasColumnOrder(1)
                        .HasDefaultValueSql("nextval('\"UserPhoneSequence\"')");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasColumnOrder(2);

                    b.Property<string>("Ddd")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ddd")
                        .HasColumnOrder(4);

                    b.Property<string>("NumberPhone")
                        .HasColumnType("text")
                        .HasColumnName("number_phone")
                        .HasColumnOrder(5);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id")
                        .HasColumnOrder(3);

                    b.HasKey("Id")
                        .HasName("pk_user_phone");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_user_phone_user_id");

                    b.ToTable("user_phone", (string)null);
                });

            modelBuilder.Entity("UserRegister.Business.EntityModels.User", b =>
                {
                    b.HasOne("UserRegister.Business.EntityModels.Address", "Address")
                        .WithOne("User")
                        .HasForeignKey("UserRegister.Business.EntityModels.User", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_address_id");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("UserRegister.Business.EntityModels.UserPhone", b =>
                {
                    b.HasOne("UserRegister.Business.EntityModels.User", "User")
                        .WithMany("UserPhones")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_phone_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserRegister.Business.EntityModels.Address", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("UserRegister.Business.EntityModels.User", b =>
                {
                    b.Navigation("UserPhones");
                });
#pragma warning restore 612, 618
        }
    }
}
