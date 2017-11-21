﻿// <auto-generated />
using ACB.FCMPushNotifications.Data;
using ACB.FCMPushNotifications.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace SampleProject.Migrations
{
    [DbContext(typeof(NotifServerDbContext))]
    [Migration("20171121205522_devices2")]
    partial class devices2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ACB.FCMPushNotifications.Data.UserDeviceToken", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("Token");

                    b.Property<int>("Platform");

                    b.HasKey("UserId", "Token");

                    b.ToTable("UserDeviceTokens");
                });
#pragma warning restore 612, 618
        }
    }
}