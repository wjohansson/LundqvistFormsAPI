﻿// <auto-generated />
using System;
using LundqvistFormsAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LundqvistFormsAPI.Migrations
{
    [DbContext(typeof(FormsContext))]
    [Migration("20230305164041_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FormsLibrary.Models.AnswerModel", b =>
                {
                    b.Property<Guid>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("AnswerDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("AnswerGroupId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DropdownChoice")
                        .HasColumnType("longtext");

                    b.Property<Guid>("FormId")
                        .HasColumnType("char(36)");

                    b.Property<string>("LongAnswer")
                        .HasColumnType("longtext");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("char(36)");

                    b.Property<int?>("Scale")
                        .HasColumnType("int");

                    b.Property<string>("ShortAnswer")
                        .HasColumnType("longtext");

                    b.Property<string>("SingleChoice")
                        .HasColumnType("longtext");

                    b.Property<TimeSpan?>("Time")
                        .HasColumnType("time(6)");

                    b.HasKey("AnswerId");

                    b.HasIndex("FormId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("FormsLibrary.Models.ChoiceModel", b =>
                {
                    b.Property<Guid>("ChoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ChoiceDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ChoiceOrder")
                        .HasColumnType("int");

                    b.Property<string>("ChoiceTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("char(36)");

                    b.HasKey("ChoiceId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Choices");
                });

            modelBuilder.Entity("FormsLibrary.Models.FormModel", b =>
                {
                    b.Property<Guid>("FormId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("FormDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FormDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FormTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("FormId");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("FormsLibrary.Models.MultipleChoiceAnswerModel", b =>
                {
                    b.Property<Guid>("MultipleChoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AnswerId")
                        .HasColumnType("char(36)");

                    b.Property<string>("MultipleChoiceTitle")
                        .HasColumnType("longtext");

                    b.HasKey("MultipleChoiceId");

                    b.HasIndex("AnswerId");

                    b.ToTable("MultipleChoiceAnswers");
                });

            modelBuilder.Entity("FormsLibrary.Models.QuestionModel", b =>
                {
                    b.Property<Guid>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("QuestionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("QuestionOption")
                        .HasColumnType("int");

                    b.Property<int>("QuestionOrder")
                        .HasColumnType("int");

                    b.Property<string>("QuestionTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("SegmentId")
                        .HasColumnType("char(36)");

                    b.HasKey("QuestionId");

                    b.HasIndex("SegmentId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("FormsLibrary.Models.ScaleModel", b =>
                {
                    b.Property<Guid>("ScaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("High")
                        .HasColumnType("int");

                    b.Property<string>("HighLabel")
                        .HasColumnType("longtext");

                    b.Property<int>("Low")
                        .HasColumnType("int");

                    b.Property<string>("LowLabel")
                        .HasColumnType("longtext");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("char(36)");

                    b.HasKey("ScaleId");

                    b.HasIndex("QuestionId")
                        .IsUnique();

                    b.ToTable("Scales");
                });

            modelBuilder.Entity("FormsLibrary.Models.SegmentModel", b =>
                {
                    b.Property<Guid>("SegmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("FormId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("SegmentDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SegmentDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("SegmentOrder")
                        .HasColumnType("int");

                    b.Property<string>("SegmentTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("SegmentId");

                    b.HasIndex("FormId");

                    b.ToTable("Segments");
                });

            modelBuilder.Entity("FormsLibrary.Models.TimeIntervalAnswerModel", b =>
                {
                    b.Property<Guid>("TimeIntervalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AnswerId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("TimeIntervalId");

                    b.HasIndex("AnswerId")
                        .IsUnique();

                    b.ToTable("TimeIntervalAnswers");
                });

            modelBuilder.Entity("FormsLibrary.Models.AnswerModel", b =>
                {
                    b.HasOne("FormsLibrary.Models.FormModel", null)
                        .WithMany("Answers")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormsLibrary.Models.QuestionModel", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FormsLibrary.Models.ChoiceModel", b =>
                {
                    b.HasOne("FormsLibrary.Models.QuestionModel", null)
                        .WithMany("ChoiceOptions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FormsLibrary.Models.MultipleChoiceAnswerModel", b =>
                {
                    b.HasOne("FormsLibrary.Models.AnswerModel", null)
                        .WithMany("MultipleChoice")
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FormsLibrary.Models.QuestionModel", b =>
                {
                    b.HasOne("FormsLibrary.Models.SegmentModel", null)
                        .WithMany("Questions")
                        .HasForeignKey("SegmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FormsLibrary.Models.ScaleModel", b =>
                {
                    b.HasOne("FormsLibrary.Models.QuestionModel", "Question")
                        .WithOne("ScaleOptions")
                        .HasForeignKey("FormsLibrary.Models.ScaleModel", "QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("FormsLibrary.Models.SegmentModel", b =>
                {
                    b.HasOne("FormsLibrary.Models.FormModel", null)
                        .WithMany("Segments")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FormsLibrary.Models.TimeIntervalAnswerModel", b =>
                {
                    b.HasOne("FormsLibrary.Models.AnswerModel", "Answer")
                        .WithOne("Interval")
                        .HasForeignKey("FormsLibrary.Models.TimeIntervalAnswerModel", "AnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answer");
                });

            modelBuilder.Entity("FormsLibrary.Models.AnswerModel", b =>
                {
                    b.Navigation("Interval")
                        .IsRequired();

                    b.Navigation("MultipleChoice");
                });

            modelBuilder.Entity("FormsLibrary.Models.FormModel", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Segments");
                });

            modelBuilder.Entity("FormsLibrary.Models.QuestionModel", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("ChoiceOptions");

                    b.Navigation("ScaleOptions")
                        .IsRequired();
                });

            modelBuilder.Entity("FormsLibrary.Models.SegmentModel", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}