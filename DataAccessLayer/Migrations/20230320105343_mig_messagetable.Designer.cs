﻿// <auto-generated />
using System;
using DataAccessLayer.concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(MyConnectionDbContext))]
    [Migration("20230320105343_mig_messagetable")]
    partial class mig_messagetable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EntityLayer.Concrate.About", b =>
                {
                    b.Property<int>("AboutID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AboutDetails1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AboutDetails2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AboutImage1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AboutImage2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AboutMapLocation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("AboutStatus")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("AboutID");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("EntityLayer.Concrate.Blog", b =>
                {
                    b.Property<int>("BlogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BlogContent")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("BlogCreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("BlogImage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("BlogStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("BlogThumbnailImage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("BlogTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("WriterID")
                        .HasColumnType("int");

                    b.HasKey("BlogID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("WriterID");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("EntityLayer.Concrate.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("CategoryStatus")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EntityLayer.Concrate.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BlogID")
                        .HasColumnType("int");

                    b.Property<string>("CommentContent")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("CommentStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("CommentTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CommentUserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CommentID");

                    b.HasIndex("BlogID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("EntityLayer.Concrate.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("ContactDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ContactMail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactMessage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("ContactStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ContactSubject")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactUserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ContactID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("EntityLayer.Concrate.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("MessageDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MessageDetails")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("MessageStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Receiver")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("MessageID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("EntityLayer.Concrate.NewsLetter", b =>
                {
                    b.Property<int>("MailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("MailStatus")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("MailID");

                    b.ToTable("NewsLetters");
                });

            modelBuilder.Entity("EntityLayer.Concrate.Notification", b =>
                {
                    b.Property<int>("NotificationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("NotificationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NotificationDetails")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("NotificationStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("NotificationType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NotificationTypeSymbol")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("NotificationID");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("EntityLayer.Concrate.Writer", b =>
                {
                    b.Property<int?>("WriterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("WriterAbout")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("WriterImage")
                        .HasColumnType("longtext");

                    b.Property<string>("WriterMail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("WriterName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("WriterPassword")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("WriterStatus")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("WriterID");

                    b.ToTable("Writers");
                });

            modelBuilder.Entity("EntityLayer.Concrate.Blog", b =>
                {
                    b.HasOne("EntityLayer.Concrate.Category", "Category")
                        .WithMany("Blogs")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrate.Writer", "Writer")
                        .WithMany("Blogs")
                        .HasForeignKey("WriterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Writer");
                });

            modelBuilder.Entity("EntityLayer.Concrate.Comment", b =>
                {
                    b.HasOne("EntityLayer.Concrate.Blog", "Blog")
                        .WithMany("Comments")
                        .HasForeignKey("BlogID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("EntityLayer.Concrate.Blog", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("EntityLayer.Concrate.Category", b =>
                {
                    b.Navigation("Blogs");
                });

            modelBuilder.Entity("EntityLayer.Concrate.Writer", b =>
                {
                    b.Navigation("Blogs");
                });
#pragma warning restore 612, 618
        }
    }
}