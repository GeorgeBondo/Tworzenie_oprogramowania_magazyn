USE [magazyn]
GO
/****** Object:  Table [dbo].[Adres]    Script Date: 13.03.2025 15:27:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adres](
	[ID_Adres] [int] IDENTITY(1,1) NOT NULL,
	[Miejscowość] [varchar](100) NOT NULL,
	[Kod_pocztowy] [char](6) NOT NULL,
	[Ulica] [varchar](100) NULL,
	[Numer_posesji] [varchar](10) NOT NULL,
	[Numer_lokalu] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Adres] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 13.03.2025 15:27:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[ID_Status] [int] IDENTITY(1,1) NOT NULL,
	[Status] [varchar](50) NOT NULL,
	[data_zapomnienia] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Uprawnienia]    Script Date: 13.03.2025 15:27:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uprawnienia](
	[ID_Uprawnienia] [int] IDENTITY(1,1) NOT NULL,
	[nazwa] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Uprawnienia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Uzytkownik]    Script Date: 13.03.2025 15:27:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uzytkownik](
	[ID_Uzytkownik] [int] IDENTITY(1,1) NOT NULL,
	[Haslo] [varchar](255) NOT NULL,
	[Imię] [varchar](50) NOT NULL,
	[Nazwisko] [varchar](50) NOT NULL,
	[PESEL] [char](11) NOT NULL,
	[Data_urodzenia] [date] NOT NULL,
	[Pieć] [char](1) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Numer_Telefonu] [varchar](15) NULL,
	[ID_Adres] [int] NULL,
	[ID_Status] [int] NULL,
	[ID_Uprawnienia] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Uzytkownik] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Uzytkownik]  WITH CHECK ADD FOREIGN KEY([ID_Adres])
REFERENCES [dbo].[Adres] ([ID_Adres])
GO
ALTER TABLE [dbo].[Uzytkownik]  WITH CHECK ADD FOREIGN KEY([ID_Status])
REFERENCES [dbo].[Status] ([ID_Status])
GO
ALTER TABLE [dbo].[Uzytkownik]  WITH CHECK ADD FOREIGN KEY([ID_Uprawnienia])
REFERENCES [dbo].[Uprawnienia] ([ID_Uprawnienia])
GO
