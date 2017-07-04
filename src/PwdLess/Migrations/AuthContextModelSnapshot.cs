﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PwdLess.Models;

namespace PwdLess.Migrations
{
    [DbContext(typeof(AuthContext))]
    partial class AuthContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PwdLess.Models.Nonce", b =>
                {
                    b.Property<string>("Contact");

                    b.Property<string>("Content");

                    b.Property<long>("Expiry");

                    b.Property<bool>("IsRegistering");

                    b.HasKey("Contact", "Content");

                    b.ToTable("Nonces");
                });

            modelBuilder.Entity("PwdLess.Models.User", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RefreshToken");

                    b.Property<long>("RefreshTokenExpiry");

                    b.Property<bool>("RefreshTokenRevoked");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PwdLess.Models.UserContact", b =>
                {
                    b.Property<string>("Contact")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserId");

                    b.HasKey("Contact");

                    b.HasIndex("UserId");

                    b.ToTable("UserContacts");
                });

            modelBuilder.Entity("PwdLess.Models.UserContact", b =>
                {
                    b.HasOne("PwdLess.Models.User", "User")
                        .WithMany("UserContacts")
                        .HasForeignKey("UserId");
                });
        }
    }
}
