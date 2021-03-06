// <auto-generated />
using System;
using DottyLogs.Server.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DottyLogs.Server.Sqlite.Migrations
{
    [DbContext(typeof(SqliteDottyDbContext))]
    [Migration("20210313125026_InitialCreate4")]
    partial class InitialCreate4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("DottyLogs.Server.DbModels.DottyLogLine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTimeUtc")
                        .HasColumnType("TEXT");

                    b.Property<long>("DottySpanId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Message")
                        .HasColumnType("TEXT");

                    b.Property<string>("TraceIdentifier")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DottySpanId");

                    b.HasIndex("TraceIdentifier");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("DottyLogs.Server.DbModels.DottySpan", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApplicationName")
                        .HasColumnType("TEXT");

                    b.Property<long?>("DottySpanId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HostName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ParentSpanIdentifier")
                        .HasColumnType("TEXT");

                    b.Property<string>("RequestUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("SpanIdentifier")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartedAtUtc")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StoppedAtUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("TraceIdentifier")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DottySpanId");

                    b.HasIndex("SpanIdentifier");

                    b.HasIndex("TraceIdentifier");

                    b.ToTable("Spans");
                });

            modelBuilder.Entity("DottyLogs.Server.DbModels.DottyTrace", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RequestUrl")
                        .HasColumnType("TEXT");

                    b.Property<long?>("SpanDataId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartedAtUtc")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StoppedAtUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("TraceIdentifier")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SpanDataId");

                    b.HasIndex("TraceIdentifier");

                    b.ToTable("Traces");
                });

            modelBuilder.Entity("DottyLogs.Server.DbModels.DottyLogLine", b =>
                {
                    b.HasOne("DottyLogs.Server.DbModels.DottySpan", null)
                        .WithMany("Logs")
                        .HasForeignKey("DottySpanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DottyLogs.Server.DbModels.DottySpan", b =>
                {
                    b.HasOne("DottyLogs.Server.DbModels.DottySpan", null)
                        .WithMany("ChildSpans")
                        .HasForeignKey("DottySpanId");
                });

            modelBuilder.Entity("DottyLogs.Server.DbModels.DottyTrace", b =>
                {
                    b.HasOne("DottyLogs.Server.DbModels.DottySpan", "SpanData")
                        .WithMany()
                        .HasForeignKey("SpanDataId");

                    b.Navigation("SpanData");
                });

            modelBuilder.Entity("DottyLogs.Server.DbModels.DottySpan", b =>
                {
                    b.Navigation("ChildSpans");

                    b.Navigation("Logs");
                });
#pragma warning restore 612, 618
        }
    }
}
