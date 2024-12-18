USE [AracKiralama]
GO
INSERT [dbo].[MiktarTur] ([Id], [StatusId], [Ad], [LastTransactionDate]) VALUES (1, 1, N'KG', CAST(N'2024-11-28T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[MiktarTur] ([Id], [StatusId], [Ad], [LastTransactionDate]) VALUES (2, 1, N'Adet', CAST(N'2024-11-28T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Personel] ([Id], [StatusId], [Ad], [Soyad], [UnvanId], [BirimId], [LastTransactionDate]) VALUES (1, 1, N'Mustafa', N'ÇAVDAROĞLU', 2, 1, CAST(N'2024-11-27T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Personel] ([Id], [StatusId], [Ad], [Soyad], [UnvanId], [BirimId], [LastTransactionDate]) VALUES (2, 1, N'Ahmet', N'DOĞAN', 1, 1, CAST(N'2024-11-27T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Personel] ([Id], [StatusId], [Ad], [Soyad], [UnvanId], [BirimId], [LastTransactionDate]) VALUES (3, 1, N'Ayşe', N'ÇAKIR', 2, 1, CAST(N'2024-11-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[PersonelSepet] ([Id], [StatusId], [PersonelId], [LastTransactionDate]) VALUES (N'1de30f9d-dc5c-4848-aa82-1f456aab4521', 1, 2, CAST(N'2024-11-28T11:18:46.550' AS DateTime))
INSERT [dbo].[PersonelSepet] ([Id], [StatusId], [PersonelId], [LastTransactionDate]) VALUES (N'463f491b-d572-492b-b28e-9766e9efaf39', 1, 1, CAST(N'2024-11-27T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[PersonelSepetUrun] ([Id], [StatusId], [PersonelSepetId], [UrunId], [Miktar], [Tutar], [LastTransactionDate]) VALUES (N'10bc3368-ebc4-4dbf-b2cc-52a035034d33', 1, N'463f491b-d572-492b-b28e-9766e9efaf39', 1, CAST(1.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), CAST(N'2024-11-27T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Unvan] ([Id], [StatusId], [Ad], [LastTransactionDate]) VALUES (1, 1, N'Komiser', CAST(N'2024-11-27T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Unvan] ([Id], [StatusId], [Ad], [LastTransactionDate]) VALUES (2, 1, N'Amir', CAST(N'2024-11-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Urun] ([Id], [StatusId], [Ad], [MiktarTurId], [LastTransactionDate]) VALUES (1, 1, N'Elma', 1, CAST(N'2024-11-27T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Urun] ([Id], [StatusId], [Ad], [MiktarTurId], [LastTransactionDate]) VALUES (2, 1, N'Kiraz', 1, CAST(N'2024-11-27T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Urun] ([Id], [StatusId], [Ad], [MiktarTurId], [LastTransactionDate]) VALUES (3, 1, N'Patates', 1, CAST(N'2024-11-27T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Urun] ([Id], [StatusId], [Ad], [MiktarTurId], [LastTransactionDate]) VALUES (4, 1, N'Makarna', 1, CAST(N'2024-11-28T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Urun] ([Id], [StatusId], [Ad], [MiktarTurId], [LastTransactionDate]) VALUES (5, 1, N'Çay', 1, CAST(N'2024-11-28T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Urun] ([Id], [StatusId], [Ad], [MiktarTurId], [LastTransactionDate]) VALUES (6, 1, N'Ekmek', 1, CAST(N'2024-11-28T00:00:00.0000000' AS DateTime2))
GO
