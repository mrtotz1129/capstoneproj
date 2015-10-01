USE [master]
GO
/****** Object:  Database [SLSDB]    Script Date: 10/1/2015 11:43:41 PM ******/
CREATE DATABASE [SLSDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SLSDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.KENNETH\MSSQL\DATA\SLSDB.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SLSDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.KENNETH\MSSQL\DATA\SLSDB_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SLSDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SLSDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SLSDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SLSDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SLSDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SLSDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SLSDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SLSDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SLSDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SLSDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SLSDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SLSDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SLSDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SLSDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SLSDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SLSDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SLSDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SLSDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SLSDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SLSDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SLSDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SLSDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SLSDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SLSDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SLSDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SLSDB] SET RECOVERY FULL 
GO
ALTER DATABASE [SLSDB] SET  MULTI_USER 
GO
ALTER DATABASE [SLSDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SLSDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SLSDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SLSDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [SLSDB]
GO
/****** Object:  Table [dbo].[AMORTIZATION]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AMORTIZATION](
	[AmortID] [int] IDENTITY(1,1) NOT NULL,
	[baseAmount] [money] NULL,
	[duration] [int] NULL,
	[ModeID] [int] NULL,
	[isPaid] [int] NULL,
	[LoanID] [int] NOT NULL,
 CONSTRAINT [PK_AmortID] PRIMARY KEY CLUSTERED 
(
	[AmortID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[APPLICABLELOAN]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[APPLICABLELOAN](
	[LoanTypeID] [int] NOT NULL,
	[MemberTypeID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[APPLICABLESAVINGS]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[APPLICABLESAVINGS](
	[MemberTypeID] [int] NOT NULL,
	[SavingsTypeID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AUDITTRAIL]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AUDITTRAIL](
	[AuditID] [int] IDENTITY(1,1) NOT NULL,
	[activity] [varchar](50) NOT NULL,
	[activityDatetime] [date] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_AuditID] PRIMARY KEY CLUSTERED 
(
	[AuditID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHARGES]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHARGES](
	[ChargeID] [int] IDENTITY(1,1) NOT NULL,
	[chargeName] [varchar](50) NOT NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_ChargeID] PRIMARY KEY CLUSTERED 
(
	[ChargeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[COMAKER]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COMAKER](
	[ComakerID] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [int] NOT NULL,
 CONSTRAINT [PK_ComakerID] PRIMARY KEY CLUSTERED 
(
	[ComakerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[COMPANY]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COMPANY](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](50) NULL,
	[street] [varchar](50) NULL,
	[brgy] [varchar](50) NULL,
	[city] [varchar](50) NULL,
	[mobileNo] [varchar](10) NULL,
	[mobileNoCountryCode] [varchar](15) NULL,
	[teleNo] [varchar](10) NULL,
	[teleNoCountryCode] [varchar](10) NULL,
 CONSTRAINT [PK_CompanyID] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CONTACTINFORMATION]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CONTACTINFORMATION](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[street] [varchar](25) NULL,
	[municipality] [varchar](25) NULL,
	[cityProvince] [varchar](25) NULL,
	[zipCode] [int] NULL,
	[residenceSince] [varchar](25) NULL,
	[telephoneNo] [int] NULL,
	[MemberID] [int] NOT NULL,
 CONSTRAINT [PK_AddressID] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CONTACTPERSON]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CONTACTPERSON](
	[contactID] [int] IDENTITY(1,1) NOT NULL,
	[contactFN] [varchar](25) NULL,
	[contactLN] [varchar](25) NULL,
	[contactMN] [varchar](25) NULL,
	[contactNo] [varchar](25) NULL,
	[MemberID] [int] NOT NULL,
 CONSTRAINT [PK_contactID] PRIMARY KEY CLUSTERED 
(
	[contactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CREDITINVESTIGATOR]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CREDITINVESTIGATOR](
	[CreditInvestigatorID] [int] IDENTITY(1,1) NOT NULL,
	[fName] [varchar](50) NOT NULL,
	[mName] [varchar](50) NULL,
	[lName] [varchar](50) NOT NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_ciID] PRIMARY KEY CLUSTERED 
(
	[CreditInvestigatorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DORMANCY]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DORMANCY](
	[DormancyID] [int] IDENTITY(1,1) NOT NULL,
	[inactivityValue] [int] NULL,
	[inactivityTime] [int] NULL,
	[deductionAmount] [decimal](18, 2) NULL,
	[isPercentage] [int] NULL,
	[deductionMode] [int] NULL,
	[activationFee] [decimal](18, 2) NULL,
	[status] [bit] NULL,
	[SavingsTypeID] [int] NOT NULL,
 CONSTRAINT [PK_DormancyID] PRIMARY KEY CLUSTERED 
(
	[DormancyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EMPLOYED]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EMPLOYED](
	[EmployedID] [int] IDENTITY(1,1) NOT NULL,
	[employerName] [varchar](50) NOT NULL,
	[employerAddress] [varchar](50) NOT NULL,
	[employerType] [int] NOT NULL,
	[employerTelNo] [varchar](7) NOT NULL,
	[dateStarted] [date] NOT NULL,
	[monthlySalary] [decimal](18, 0) NOT NULL,
	[department] [varchar](50) NOT NULL,
	[EmploymentInformationID] [int] NOT NULL,
 CONSTRAINT [PK_EmployedID] PRIMARY KEY CLUSTERED 
(
	[EmployedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EMPLOYMENTINFORMATION]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPLOYMENTINFORMATION](
	[EmploymentInformationID] [int] IDENTITY(1,1) NOT NULL,
	[employmentNo] [int] NOT NULL,
	[MemberID] [int] NOT NULL,
 CONSTRAINT [PK_EmploymentInformationID] PRIMARY KEY CLUSTERED 
(
	[EmploymentInformationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FAMILYBACKGROUND]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FAMILYBACKGROUND](
	[FamilyID] [int] IDENTITY(1,1) NOT NULL,
	[fName] [varchar](50) NOT NULL,
	[mName] [varchar](50) NOT NULL,
	[lName] [varchar](50) NOT NULL,
	[birthDate] [date] NOT NULL,
	[gender] [bit] NOT NULL,
	[relationship] [varchar](50) NOT NULL,
	[MemberID] [int] NOT NULL,
 CONSTRAINT [PK_FamilyID] PRIMARY KEY CLUSTERED 
(
	[FamilyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GRANTEDLOAN]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GRANTEDLOAN](
	[GrantorID] [int] NOT NULL,
	[LoanID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GRANTOR]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GRANTOR](
	[GrantorID] [int] IDENTITY(1,1) NOT NULL,
	[fName] [varchar](50) NOT NULL,
	[mName] [varchar](50) NULL,
	[lName] [varchar](50) NOT NULL,
	[position] [varchar](50) NOT NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_lgID] PRIMARY KEY CLUSTERED 
(
	[GrantorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOAN]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOAN](
	[LoanID] [int] IDENTITY(1,1) NOT NULL,
	[LoanTypeID] [int] NOT NULL,
	[applyAmount] [money] NOT NULL,
	[TermID] [int] NOT NULL,
	[ModeID] [int] NOT NULL,
	[dateApplied] [date] NOT NULL,
	[isApproved] [bit] NOT NULL,
	[MemberID] [int] NOT NULL,
	[reason] [varchar](150) NOT NULL,
	[approveAmount] [money] NOT NULL,
	[totalInterest] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_LoanID] PRIMARY KEY CLUSTERED 
(
	[LoanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOANRATE]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOANRATE](
	[ModeID] [int] NOT NULL,
	[ChargeID] [int] NOT NULL,
	[TermID] [int] NOT NULL,
	[LoanTypeID] [int] NOT NULL,
	[rate] [decimal](9, 2) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LOANTRANSACTION]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOANTRANSACTION](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[transactionDatetime] [date] NOT NULL,
	[transactionType] [varchar](50) NOT NULL,
	[amount] [money] NOT NULL,
	[currentBalance] [money] NOT NULL,
	[LoanID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_LoanTransactionID] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOANTYPE]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOANTYPE](
	[LoanTypeID] [int] IDENTITY(1,1) NOT NULL,
	[loanTypeName] [varchar](50) NULL,
	[minAmount] [money] NULL,
	[maxAmount] [money] NULL,
	[noOfComaker] [int] NULL,
	[entitlement] [decimal](18, 2) NULL,
	[eligibility] [decimal](18, 2) NULL,
	[status] [bit] NULL,
	[gracePeriod] [int] NULL,
	[graceTime] [int] NULL,
	[penalty] [decimal](18, 2) NULL,
 CONSTRAINT [PK_LoanTypeID] PRIMARY KEY CLUSTERED 
(
	[LoanTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MEMBER]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MEMBER](
	[MemberID] [int] IDENTITY(1,1) NOT NULL,
	[fName] [varchar](50) NOT NULL,
	[mName] [varchar](50) NOT NULL,
	[lName] [varchar](50) NOT NULL,
	[gender] [bit] NULL,
	[birthDate] [date] NULL,
	[civilStatus] [varchar](10) NULL,
	[gsisNo] [varchar](50) NULL,
	[educAttainment] [int] NULL,
	[paidMembershipFee] [decimal](9, 2) NULL,
	[applyDate] [date] NULL,
	[seminarDate] [date] NULL,
	[isActive] [bit] NULL,
	[MemberTypeID] [int] NOT NULL,
	[CreditInvestigatorID] [int] NOT NULL,
 CONSTRAINT [PK_MemberID] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MEMBERTYPE]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MEMBERTYPE](
	[MemberTypeID] [int] IDENTITY(1,1) NOT NULL,
	[MemberTypeName] [varchar](50) NULL,
	[MinAgeRequired] [int] NULL,
	[MaxAgeRequired] [int] NULL,
	[Fee] [decimal](18, 0) NULL,
	[SavingsApplicable] [bit] NULL,
	[TimeApplicable] [bit] NULL,
	[LoanApplicable] [bit] NULL,
	[ShareRequired] [decimal](18, 2) NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_MemberTypeID] PRIMARY KEY CLUSTERED 
(
	[MemberTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MODE]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MODE](
	[ModeID] [int] IDENTITY(1,1) NOT NULL,
	[modeName] [varchar](50) NOT NULL,
	[daysInterval] [int] NOT NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_ModeID] PRIMARY KEY CLUSTERED 
(
	[ModeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[REBATE]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[REBATE](
	[RebateID] [int] IDENTITY(1,1) NOT NULL,
	[rebateAmount] [decimal](9, 2) NOT NULL,
	[isWithdrawn] [bit] NOT NULL,
	[MemberID] [int] NOT NULL,
 CONSTRAINT [PK_RebateID] PRIMARY KEY CLUSTERED 
(
	[RebateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SAVINGSACCOUNT]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SAVINGSACCOUNT](
	[SavingsAccountID] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [int] NOT NULL,
	[SavingsTypeID] [int] NOT NULL,
	[dateOpened] [date] NULL,
	[dateClosed] [date] NULL,
	[currentBalance] [decimal](18, 2) NULL,
 CONSTRAINT [PK_SavingsAccountID] PRIMARY KEY CLUSTERED 
(
	[SavingsAccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SAVINGSTRANSACTION]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SAVINGSTRANSACTION](
	[SavingsTransactionID] [int] IDENTITY(1,1) NOT NULL,
	[transactionDate] [date] NULL,
	[transactionType] [varchar](50) NULL,
	[transactionAmount] [decimal](18, 2) NULL,
	[transactionRepresentative] [varchar](100) NULL,
	[currentBalance] [decimal](18, 2) NULL,
	[SavingsAccountID] [int] NOT NULL,
 CONSTRAINT [PK_SavingsTransactionID] PRIMARY KEY CLUSTERED 
(
	[SavingsTransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SAVINGSTYPE]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SAVINGSTYPE](
	[SavingsTypeID] [int] IDENTITY(1,1) NOT NULL,
	[SavingsTypeName] [varchar](50) NULL,
	[initialDeposit] [decimal](18, 2) NULL,
	[maintainingBalance] [decimal](18, 2) NULL,
	[balanceToEarn] [decimal](18, 2) NULL,
	[interestRate] [decimal](5, 2) NULL,
	[maxWithdrawAmount] [decimal](18, 2) NULL,
	[maxWithdrawMode] [int] NULL,
	[hasDormancy] [bit] NOT NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_SavingsTypeID] PRIMARY KEY CLUSTERED 
(
	[SavingsTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SELFEMPLOYED]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SELFEMPLOYED](
	[SelfEmployedID] [int] IDENTITY(1,1) NOT NULL,
	[typeOfBusiness] [varchar](50) NOT NULL,
	[startingCapital] [decimal](9, 2) NOT NULL,
	[monthlyNetIncome] [money] NOT NULL,
	[businessAddress] [varchar](50) NOT NULL,
	[presentCapital] [money] NOT NULL,
	[EmploymentInformationID] [int] NOT NULL,
 CONSTRAINT [PK_SelfEmployedID] PRIMARY KEY CLUSTERED 
(
	[SelfEmployedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SHARECAPITAL]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SHARECAPITAL](
	[ShareCapitalID] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [int] NOT NULL,
	[currentBalance] [money] NOT NULL,
	[multiplier] [int] NOT NULL,
 CONSTRAINT [PK_ShareCapitalNo] PRIMARY KEY CLUSTERED 
(
	[ShareCapitalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SHARECAPITALTRANSACTION]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SHARECAPITALTRANSACTION](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[transactionDatetime] [date] NOT NULL,
	[transactionType] [varchar](50) NOT NULL,
	[amount] [money] NOT NULL,
	[currentBalance] [money] NOT NULL,
	[ShareCapitalID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_ShareCapitalTransactionID] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TERM]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TERM](
	[TermID] [int] IDENTITY(1,1) NOT NULL,
	[noOfDays] [int] NOT NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_TermID] PRIMARY KEY CLUSTERED 
(
	[TermID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMEDEPOSITACCOUNT]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMEDEPOSITACCOUNT](
	[TimeDepositAccountID] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [int] NOT NULL,
	[TimeDepositRatesID] [int] NOT NULL,
	[dateOpened] [date] NULL,
	[dateMaturity] [date] NULL,
	[dateClosed] [date] NULL,
	[currentBalance] [decimal](18, 2) NULL,
	[isClosed] [bit] NULL,
 CONSTRAINT [PK_TimeDepositAccountID] PRIMARY KEY CLUSTERED 
(
	[TimeDepositAccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMEDEPOSITPENALTY]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMEDEPOSITPENALTY](
	[TimeDepositPenaltyID] [int] IDENTITY(1,1) NOT NULL,
	[minElapsed] [decimal](5, 2) NULL,
	[maxElapsed] [decimal](5, 2) NULL,
	[reducedBy] [decimal](5, 2) NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_TimeDepositPenaltyID] PRIMARY KEY CLUSTERED 
(
	[TimeDepositPenaltyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMEDEPOSITRATES]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMEDEPOSITRATES](
	[TimeDepositRatesID] [int] IDENTITY(1,1) NOT NULL,
	[noOfDays] [int] NULL,
	[minAmount] [decimal](18, 2) NULL,
	[maxAmount] [decimal](18, 2) NULL,
	[interest] [decimal](18, 2) NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_TimeDepositRatesID] PRIMARY KEY CLUSTERED 
(
	[TimeDepositRatesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMEDEPOSITTRANSACTION]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TIMEDEPOSITTRANSACTION](
	[TimeDepositTransactionID] [int] IDENTITY(1,1) NOT NULL,
	[transactionDate] [date] NULL,
	[transactionType] [varchar](50) NULL,
	[transactionAmount] [decimal](18, 2) NULL,
	[transactionRepresentative] [varchar](100) NULL,
	[TimeDepositAccountID] [int] NOT NULL,
 CONSTRAINT [PK_TimeDepositTransactionID] PRIMARY KEY CLUSTERED 
(
	[TimeDepositTransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USER]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USER](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[fName] [varchar](50) NOT NULL,
	[mName] [varchar](50) NULL,
	[lName] [varchar](50) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[accountID] [int] NOT NULL,
	[securityQuestion] [varchar](100) NULL,
	[securityAnswer] [varchar](100) NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_UserID] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[COMPANYDETAILSVIEW]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[COMPANYDETAILSVIEW] As
SELECT COMPANY.CompanyName as [COMPANY NAME], CONCAT(COMPANY.street,', ',COMPANY.brgy,', ',COMPANY.city,', ') as [ADDRESS], CONCAT(COMPANY.mobileNo,' : ',COMPANY.teleNo) as [CONTACT]
FROM COMPANY

GO
/****** Object:  View [dbo].[MEMBERVIEW]    Script Date: 10/1/2015 11:43:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[MEMBERVIEW] As
SELECT CONCAT(MEMBER.fName,' ',MEMBER.mName,' ',MEMBER.lName) as [MEMBER NAME], CASE MEMBER.gender when 0 then 'Female' else 'Male' end as [GENDER]
FROM MEMBER

GO
INSERT [dbo].[APPLICABLELOAN] ([LoanTypeID], [MemberTypeID]) VALUES (1, 1)
INSERT [dbo].[APPLICABLELOAN] ([LoanTypeID], [MemberTypeID]) VALUES (1, 3)
INSERT [dbo].[APPLICABLELOAN] ([LoanTypeID], [MemberTypeID]) VALUES (1, 1)
INSERT [dbo].[APPLICABLELOAN] ([LoanTypeID], [MemberTypeID]) VALUES (1, 3)
SET IDENTITY_INSERT [dbo].[CHARGES] ON 

INSERT [dbo].[CHARGES] ([ChargeID], [chargeName], [status]) VALUES (1, N'Interest On Loan', 1)
INSERT [dbo].[CHARGES] ([ChargeID], [chargeName], [status]) VALUES (2, N'Miscelleanous Fee', 1)
INSERT [dbo].[CHARGES] ([ChargeID], [chargeName], [status]) VALUES (3, N'Service Fee', 1)
SET IDENTITY_INSERT [dbo].[CHARGES] OFF
SET IDENTITY_INSERT [dbo].[COMPANY] ON 

INSERT [dbo].[COMPANY] ([CompanyID], [CompanyName], [street], [brgy], [city], [mobileNo], [mobileNoCountryCode], [teleNo], [teleNoCountryCode]) VALUES (1, N'Mandaluyong Trader''s Development Cooperative', N'807 Inocentes Street', N'Baranggay Pag-asa', N'Mandaluyong City', N'9999999999', N'+63', N'999-9999', N'')
SET IDENTITY_INSERT [dbo].[COMPANY] OFF
SET IDENTITY_INSERT [dbo].[CREDITINVESTIGATOR] ON 

INSERT [dbo].[CREDITINVESTIGATOR] ([CreditInvestigatorID], [fName], [mName], [lName], [status]) VALUES (1, N'Sir John Paul', N'Arguelles', N'Cutaran', 1)
INSERT [dbo].[CREDITINVESTIGATOR] ([CreditInvestigatorID], [fName], [mName], [lName], [status]) VALUES (2, N'Kenneth', N'', N'Avecilla', 1)
INSERT [dbo].[CREDITINVESTIGATOR] ([CreditInvestigatorID], [fName], [mName], [lName], [status]) VALUES (3, N'Johann', N'Arcangel', N'Calimag', 1)
INSERT [dbo].[CREDITINVESTIGATOR] ([CreditInvestigatorID], [fName], [mName], [lName], [status]) VALUES (4, N'Celine Tracy', N'Balota', N'Joaquin', 1)
SET IDENTITY_INSERT [dbo].[CREDITINVESTIGATOR] OFF
INSERT [dbo].[LOANRATE] ([ModeID], [ChargeID], [TermID], [LoanTypeID], [rate]) VALUES (2, 1, 2, 1, CAST(1.50 AS Decimal(9, 2)))
INSERT [dbo].[LOANRATE] ([ModeID], [ChargeID], [TermID], [LoanTypeID], [rate]) VALUES (2, 1, 2, 1, CAST(2.00 AS Decimal(9, 2)))
INSERT [dbo].[LOANRATE] ([ModeID], [ChargeID], [TermID], [LoanTypeID], [rate]) VALUES (3, 1, 3, 1, CAST(2.50 AS Decimal(9, 2)))
INSERT [dbo].[LOANRATE] ([ModeID], [ChargeID], [TermID], [LoanTypeID], [rate]) VALUES (3, 1, 3, 1, CAST(3.00 AS Decimal(9, 2)))
INSERT [dbo].[LOANRATE] ([ModeID], [ChargeID], [TermID], [LoanTypeID], [rate]) VALUES (3, 2, 3, 1, CAST(1.60 AS Decimal(9, 2)))
INSERT [dbo].[LOANRATE] ([ModeID], [ChargeID], [TermID], [LoanTypeID], [rate]) VALUES (2, 3, 2, 1, CAST(1.45 AS Decimal(9, 2)))
INSERT [dbo].[LOANRATE] ([ModeID], [ChargeID], [TermID], [LoanTypeID], [rate]) VALUES (3, 3, 3, 1, CAST(1.85 AS Decimal(9, 2)))
INSERT [dbo].[LOANRATE] ([ModeID], [ChargeID], [TermID], [LoanTypeID], [rate]) VALUES (2, 2, 2, 1, CAST(1.20 AS Decimal(9, 2)))
INSERT [dbo].[LOANRATE] ([ModeID], [ChargeID], [TermID], [LoanTypeID], [rate]) VALUES (2, 2, 2, 1, CAST(1.40 AS Decimal(9, 2)))
INSERT [dbo].[LOANRATE] ([ModeID], [ChargeID], [TermID], [LoanTypeID], [rate]) VALUES (3, 2, 3, 1, CAST(1.80 AS Decimal(9, 2)))
INSERT [dbo].[LOANRATE] ([ModeID], [ChargeID], [TermID], [LoanTypeID], [rate]) VALUES (2, 3, 2, 1, CAST(1.65 AS Decimal(9, 2)))
INSERT [dbo].[LOANRATE] ([ModeID], [ChargeID], [TermID], [LoanTypeID], [rate]) VALUES (3, 3, 3, 1, CAST(2.05 AS Decimal(9, 2)))
INSERT [dbo].[LOANRATE] ([ModeID], [ChargeID], [TermID], [LoanTypeID], [rate]) VALUES (2, 1, 2, 1, CAST(1.50 AS Decimal(9, 2)))
INSERT [dbo].[LOANRATE] ([ModeID], [ChargeID], [TermID], [LoanTypeID], [rate]) VALUES (2, 1, 2, 1, CAST(2.00 AS Decimal(9, 2)))
INSERT [dbo].[LOANRATE] ([ModeID], [ChargeID], [TermID], [LoanTypeID], [rate]) VALUES (3, 1, 3, 1, CAST(2.50 AS Decimal(9, 2)))
INSERT [dbo].[LOANRATE] ([ModeID], [ChargeID], [TermID], [LoanTypeID], [rate]) VALUES (3, 1, 3, 1, CAST(3.00 AS Decimal(9, 2)))
INSERT [dbo].[LOANRATE] ([ModeID], [ChargeID], [TermID], [LoanTypeID], [rate]) VALUES (3, 2, 3, 1, CAST(1.60 AS Decimal(9, 2)))
INSERT [dbo].[LOANRATE] ([ModeID], [ChargeID], [TermID], [LoanTypeID], [rate]) VALUES (2, 3, 2, 1, CAST(1.45 AS Decimal(9, 2)))
INSERT [dbo].[LOANRATE] ([ModeID], [ChargeID], [TermID], [LoanTypeID], [rate]) VALUES (3, 3, 3, 1, CAST(1.85 AS Decimal(9, 2)))
INSERT [dbo].[LOANRATE] ([ModeID], [ChargeID], [TermID], [LoanTypeID], [rate]) VALUES (2, 2, 2, 1, CAST(1.20 AS Decimal(9, 2)))
INSERT [dbo].[LOANRATE] ([ModeID], [ChargeID], [TermID], [LoanTypeID], [rate]) VALUES (2, 2, 2, 1, CAST(1.40 AS Decimal(9, 2)))
INSERT [dbo].[LOANRATE] ([ModeID], [ChargeID], [TermID], [LoanTypeID], [rate]) VALUES (3, 2, 3, 1, CAST(1.80 AS Decimal(9, 2)))
INSERT [dbo].[LOANRATE] ([ModeID], [ChargeID], [TermID], [LoanTypeID], [rate]) VALUES (2, 3, 2, 1, CAST(1.65 AS Decimal(9, 2)))
INSERT [dbo].[LOANRATE] ([ModeID], [ChargeID], [TermID], [LoanTypeID], [rate]) VALUES (3, 3, 3, 1, CAST(2.05 AS Decimal(9, 2)))
SET IDENTITY_INSERT [dbo].[LOANTYPE] ON 

INSERT [dbo].[LOANTYPE] ([LoanTypeID], [loanTypeName], [minAmount], [maxAmount], [noOfComaker], [entitlement], [eligibility], [status], [gracePeriod], [graceTime], [penalty]) VALUES (1, N'Regular Loan', 10000.0000, 25000.0000, 3, CAST(300.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), 1, 2, 1, CAST(1.55 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[LOANTYPE] OFF
SET IDENTITY_INSERT [dbo].[MEMBER] ON 

INSERT [dbo].[MEMBER] ([MemberID], [fName], [mName], [lName], [gender], [birthDate], [civilStatus], [gsisNo], [educAttainment], [paidMembershipFee], [applyDate], [seminarDate], [isActive], [MemberTypeID], [CreditInvestigatorID]) VALUES (1, N'Sir John Paul', N'Arguelles', N'Cutaran', 0, CAST(0xD01C0B00 AS Date), N'0', NULL, 2, CAST(100.00 AS Decimal(9, 2)), CAST(0x7F3A0B00 AS Date), CAST(0x7F3A0B00 AS Date), 1, 1, 1)
SET IDENTITY_INSERT [dbo].[MEMBER] OFF
SET IDENTITY_INSERT [dbo].[MEMBERTYPE] ON 

INSERT [dbo].[MEMBERTYPE] ([MemberTypeID], [MemberTypeName], [MinAgeRequired], [MaxAgeRequired], [Fee], [SavingsApplicable], [TimeApplicable], [LoanApplicable], [ShareRequired], [status]) VALUES (1, N'Regular Member', 20, 35, CAST(150 AS Decimal(18, 0)), 1, 1, 1, CAST(3500.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[MEMBERTYPE] ([MemberTypeID], [MemberTypeName], [MinAgeRequired], [MaxAgeRequired], [Fee], [SavingsApplicable], [TimeApplicable], [LoanApplicable], [ShareRequired], [status]) VALUES (2, N'Associate Member', 20, 35, CAST(200 AS Decimal(18, 0)), 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[MEMBERTYPE] ([MemberTypeID], [MemberTypeName], [MinAgeRequired], [MaxAgeRequired], [Fee], [SavingsApplicable], [TimeApplicable], [LoanApplicable], [ShareRequired], [status]) VALUES (3, N'VIP', 20, 35, CAST(150 AS Decimal(18, 0)), 1, 1, 1, CAST(5000.00 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[MEMBERTYPE] OFF
SET IDENTITY_INSERT [dbo].[MODE] ON 

INSERT [dbo].[MODE] ([ModeID], [modeName], [daysInterval], [status]) VALUES (1, N'Daily', 1, 1)
INSERT [dbo].[MODE] ([ModeID], [modeName], [daysInterval], [status]) VALUES (2, N'Weekly', 7, 1)
INSERT [dbo].[MODE] ([ModeID], [modeName], [daysInterval], [status]) VALUES (3, N'Monthly', 30, 1)
INSERT [dbo].[MODE] ([ModeID], [modeName], [daysInterval], [status]) VALUES (4, N'Yearly', 365, 1)
SET IDENTITY_INSERT [dbo].[MODE] OFF
SET IDENTITY_INSERT [dbo].[SHARECAPITAL] ON 

INSERT [dbo].[SHARECAPITAL] ([ShareCapitalID], [MemberID], [currentBalance], [multiplier]) VALUES (3, 1, 5500.0000, 2)
SET IDENTITY_INSERT [dbo].[SHARECAPITAL] OFF
SET IDENTITY_INSERT [dbo].[TERM] ON 

INSERT [dbo].[TERM] ([TermID], [noOfDays], [status]) VALUES (1, 90, 1)
INSERT [dbo].[TERM] ([TermID], [noOfDays], [status]) VALUES (2, 180, 1)
INSERT [dbo].[TERM] ([TermID], [noOfDays], [status]) VALUES (3, 365, 1)
SET IDENTITY_INSERT [dbo].[TERM] OFF
SET IDENTITY_INSERT [dbo].[USER] ON 

INSERT [dbo].[USER] ([UserID], [fName], [mName], [lName], [username], [password], [accountID], [securityQuestion], [securityAnswer], [status]) VALUES (1, N'Sir John Paul', N'Arguelles', N'Cutaran', N'admin', N'admin', 1, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[USER] OFF
ALTER TABLE [dbo].[AMORTIZATION]  WITH CHECK ADD  CONSTRAINT [FK_Amort_LoanID] FOREIGN KEY([LoanID])
REFERENCES [dbo].[LOAN] ([LoanID])
GO
ALTER TABLE [dbo].[AMORTIZATION] CHECK CONSTRAINT [FK_Amort_LoanID]
GO
ALTER TABLE [dbo].[AMORTIZATION]  WITH CHECK ADD  CONSTRAINT [FK_Amort_ModeID] FOREIGN KEY([ModeID])
REFERENCES [dbo].[MODE] ([ModeID])
GO
ALTER TABLE [dbo].[AMORTIZATION] CHECK CONSTRAINT [FK_Amort_ModeID]
GO
ALTER TABLE [dbo].[APPLICABLELOAN]  WITH CHECK ADD  CONSTRAINT [FK_ApplicableLoan_LoanTypeID] FOREIGN KEY([LoanTypeID])
REFERENCES [dbo].[LOANTYPE] ([LoanTypeID])
GO
ALTER TABLE [dbo].[APPLICABLELOAN] CHECK CONSTRAINT [FK_ApplicableLoan_LoanTypeID]
GO
ALTER TABLE [dbo].[APPLICABLELOAN]  WITH CHECK ADD  CONSTRAINT [FK_ApplicableLoan_MemberTypeID] FOREIGN KEY([MemberTypeID])
REFERENCES [dbo].[MEMBERTYPE] ([MemberTypeID])
GO
ALTER TABLE [dbo].[APPLICABLELOAN] CHECK CONSTRAINT [FK_ApplicableLoan_MemberTypeID]
GO
ALTER TABLE [dbo].[APPLICABLESAVINGS]  WITH CHECK ADD  CONSTRAINT [FK_ApplicableSavings_MemberTypeID] FOREIGN KEY([MemberTypeID])
REFERENCES [dbo].[MEMBERTYPE] ([MemberTypeID])
GO
ALTER TABLE [dbo].[APPLICABLESAVINGS] CHECK CONSTRAINT [FK_ApplicableSavings_MemberTypeID]
GO
ALTER TABLE [dbo].[APPLICABLESAVINGS]  WITH CHECK ADD  CONSTRAINT [FK_ApplicableSavings_SavingsTypeID] FOREIGN KEY([SavingsTypeID])
REFERENCES [dbo].[SAVINGSTYPE] ([SavingsTypeID])
GO
ALTER TABLE [dbo].[APPLICABLESAVINGS] CHECK CONSTRAINT [FK_ApplicableSavings_SavingsTypeID]
GO
ALTER TABLE [dbo].[AUDITTRAIL]  WITH CHECK ADD  CONSTRAINT [FK_audittrailUserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[USER] ([UserID])
GO
ALTER TABLE [dbo].[AUDITTRAIL] CHECK CONSTRAINT [FK_audittrailUserID]
GO
ALTER TABLE [dbo].[COMAKER]  WITH CHECK ADD  CONSTRAINT [FK_Comaker_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[MEMBER] ([MemberID])
GO
ALTER TABLE [dbo].[COMAKER] CHECK CONSTRAINT [FK_Comaker_MemberID]
GO
ALTER TABLE [dbo].[CONTACTINFORMATION]  WITH CHECK ADD  CONSTRAINT [FK_Address_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[MEMBER] ([MemberID])
GO
ALTER TABLE [dbo].[CONTACTINFORMATION] CHECK CONSTRAINT [FK_Address_MemberID]
GO
ALTER TABLE [dbo].[CONTACTPERSON]  WITH CHECK ADD  CONSTRAINT [FK_Contact_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[MEMBER] ([MemberID])
GO
ALTER TABLE [dbo].[CONTACTPERSON] CHECK CONSTRAINT [FK_Contact_MemberID]
GO
ALTER TABLE [dbo].[DORMANCY]  WITH CHECK ADD  CONSTRAINT [FK_Dormancy_SavingsTypeID] FOREIGN KEY([SavingsTypeID])
REFERENCES [dbo].[SAVINGSTYPE] ([SavingsTypeID])
GO
ALTER TABLE [dbo].[DORMANCY] CHECK CONSTRAINT [FK_Dormancy_SavingsTypeID]
GO
ALTER TABLE [dbo].[EMPLOYED]  WITH CHECK ADD  CONSTRAINT [FK_Employed_EmploymentInformationID] FOREIGN KEY([EmploymentInformationID])
REFERENCES [dbo].[EMPLOYMENTINFORMATION] ([EmploymentInformationID])
GO
ALTER TABLE [dbo].[EMPLOYED] CHECK CONSTRAINT [FK_Employed_EmploymentInformationID]
GO
ALTER TABLE [dbo].[EMPLOYMENTINFORMATION]  WITH CHECK ADD  CONSTRAINT [FK_EmploymentInformation_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[MEMBER] ([MemberID])
GO
ALTER TABLE [dbo].[EMPLOYMENTINFORMATION] CHECK CONSTRAINT [FK_EmploymentInformation_MemberID]
GO
ALTER TABLE [dbo].[FAMILYBACKGROUND]  WITH CHECK ADD  CONSTRAINT [FK_Family_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[MEMBER] ([MemberID])
GO
ALTER TABLE [dbo].[FAMILYBACKGROUND] CHECK CONSTRAINT [FK_Family_MemberID]
GO
ALTER TABLE [dbo].[GRANTEDLOAN]  WITH CHECK ADD  CONSTRAINT [FK_GrantedLoan_GrantorID] FOREIGN KEY([GrantorID])
REFERENCES [dbo].[GRANTOR] ([GrantorID])
GO
ALTER TABLE [dbo].[GRANTEDLOAN] CHECK CONSTRAINT [FK_GrantedLoan_GrantorID]
GO
ALTER TABLE [dbo].[GRANTEDLOAN]  WITH CHECK ADD  CONSTRAINT [FK_GrantedLoan_LoanID] FOREIGN KEY([LoanID])
REFERENCES [dbo].[LOAN] ([LoanID])
GO
ALTER TABLE [dbo].[GRANTEDLOAN] CHECK CONSTRAINT [FK_GrantedLoan_LoanID]
GO
ALTER TABLE [dbo].[LOAN]  WITH CHECK ADD  CONSTRAINT [FK_Loan_LoanTypeID] FOREIGN KEY([LoanTypeID])
REFERENCES [dbo].[LOANTYPE] ([LoanTypeID])
GO
ALTER TABLE [dbo].[LOAN] CHECK CONSTRAINT [FK_Loan_LoanTypeID]
GO
ALTER TABLE [dbo].[LOAN]  WITH CHECK ADD  CONSTRAINT [FK_Loan_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[MEMBER] ([MemberID])
GO
ALTER TABLE [dbo].[LOAN] CHECK CONSTRAINT [FK_Loan_MemberID]
GO
ALTER TABLE [dbo].[LOAN]  WITH CHECK ADD  CONSTRAINT [FK_Loan_ModeID] FOREIGN KEY([ModeID])
REFERENCES [dbo].[MODE] ([ModeID])
GO
ALTER TABLE [dbo].[LOAN] CHECK CONSTRAINT [FK_Loan_ModeID]
GO
ALTER TABLE [dbo].[LOAN]  WITH CHECK ADD  CONSTRAINT [FK_Loan_TermID] FOREIGN KEY([TermID])
REFERENCES [dbo].[TERM] ([TermID])
GO
ALTER TABLE [dbo].[LOAN] CHECK CONSTRAINT [FK_Loan_TermID]
GO
ALTER TABLE [dbo].[LOANRATE]  WITH CHECK ADD  CONSTRAINT [FK_Rate_ChargeID] FOREIGN KEY([ChargeID])
REFERENCES [dbo].[CHARGES] ([ChargeID])
GO
ALTER TABLE [dbo].[LOANRATE] CHECK CONSTRAINT [FK_Rate_ChargeID]
GO
ALTER TABLE [dbo].[LOANRATE]  WITH CHECK ADD  CONSTRAINT [FK_Rate_LoanTypeID] FOREIGN KEY([LoanTypeID])
REFERENCES [dbo].[LOANTYPE] ([LoanTypeID])
GO
ALTER TABLE [dbo].[LOANRATE] CHECK CONSTRAINT [FK_Rate_LoanTypeID]
GO
ALTER TABLE [dbo].[LOANRATE]  WITH CHECK ADD  CONSTRAINT [FK_Rate_ModeID] FOREIGN KEY([ModeID])
REFERENCES [dbo].[MODE] ([ModeID])
GO
ALTER TABLE [dbo].[LOANRATE] CHECK CONSTRAINT [FK_Rate_ModeID]
GO
ALTER TABLE [dbo].[LOANRATE]  WITH CHECK ADD  CONSTRAINT [FK_Rate_TermID] FOREIGN KEY([TermID])
REFERENCES [dbo].[TERM] ([TermID])
GO
ALTER TABLE [dbo].[LOANRATE] CHECK CONSTRAINT [FK_Rate_TermID]
GO
ALTER TABLE [dbo].[LOANTRANSACTION]  WITH CHECK ADD  CONSTRAINT [FK_LoanTransaction_LoanID] FOREIGN KEY([LoanID])
REFERENCES [dbo].[LOAN] ([LoanID])
GO
ALTER TABLE [dbo].[LOANTRANSACTION] CHECK CONSTRAINT [FK_LoanTransaction_LoanID]
GO
ALTER TABLE [dbo].[LOANTRANSACTION]  WITH CHECK ADD  CONSTRAINT [FK_LoanTransaction_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[USER] ([UserID])
GO
ALTER TABLE [dbo].[LOANTRANSACTION] CHECK CONSTRAINT [FK_LoanTransaction_UserID]
GO
ALTER TABLE [dbo].[MEMBER]  WITH CHECK ADD  CONSTRAINT [FK_Member_CreditInvestigatorID] FOREIGN KEY([CreditInvestigatorID])
REFERENCES [dbo].[CREDITINVESTIGATOR] ([CreditInvestigatorID])
GO
ALTER TABLE [dbo].[MEMBER] CHECK CONSTRAINT [FK_Member_CreditInvestigatorID]
GO
ALTER TABLE [dbo].[MEMBER]  WITH CHECK ADD  CONSTRAINT [FK_Member_MemberTypeID] FOREIGN KEY([MemberTypeID])
REFERENCES [dbo].[MEMBERTYPE] ([MemberTypeID])
GO
ALTER TABLE [dbo].[MEMBER] CHECK CONSTRAINT [FK_Member_MemberTypeID]
GO
ALTER TABLE [dbo].[REBATE]  WITH CHECK ADD  CONSTRAINT [FK_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[MEMBER] ([MemberID])
GO
ALTER TABLE [dbo].[REBATE] CHECK CONSTRAINT [FK_MemberID]
GO
ALTER TABLE [dbo].[SAVINGSACCOUNT]  WITH CHECK ADD  CONSTRAINT [FK_SavingsAccount_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[MEMBER] ([MemberID])
GO
ALTER TABLE [dbo].[SAVINGSACCOUNT] CHECK CONSTRAINT [FK_SavingsAccount_MemberID]
GO
ALTER TABLE [dbo].[SAVINGSACCOUNT]  WITH CHECK ADD  CONSTRAINT [FK_SavingsAccount_SavingsTypeID] FOREIGN KEY([SavingsTypeID])
REFERENCES [dbo].[SAVINGSTYPE] ([SavingsTypeID])
GO
ALTER TABLE [dbo].[SAVINGSACCOUNT] CHECK CONSTRAINT [FK_SavingsAccount_SavingsTypeID]
GO
ALTER TABLE [dbo].[SAVINGSTRANSACTION]  WITH CHECK ADD  CONSTRAINT [FK_SavingsTransaction_SavingsAccountID] FOREIGN KEY([SavingsAccountID])
REFERENCES [dbo].[SAVINGSACCOUNT] ([SavingsAccountID])
GO
ALTER TABLE [dbo].[SAVINGSTRANSACTION] CHECK CONSTRAINT [FK_SavingsTransaction_SavingsAccountID]
GO
ALTER TABLE [dbo].[SELFEMPLOYED]  WITH CHECK ADD  CONSTRAINT [FK_SelfEmployed_EmploymentInformationID] FOREIGN KEY([EmploymentInformationID])
REFERENCES [dbo].[EMPLOYMENTINFORMATION] ([EmploymentInformationID])
GO
ALTER TABLE [dbo].[SELFEMPLOYED] CHECK CONSTRAINT [FK_SelfEmployed_EmploymentInformationID]
GO
ALTER TABLE [dbo].[SHARECAPITAL]  WITH CHECK ADD  CONSTRAINT [FK_ShareCapital_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[MEMBER] ([MemberID])
GO
ALTER TABLE [dbo].[SHARECAPITAL] CHECK CONSTRAINT [FK_ShareCapital_MemberID]
GO
ALTER TABLE [dbo].[SHARECAPITALTRANSACTION]  WITH CHECK ADD  CONSTRAINT [FK_ShareCapitalTransaction_ShareCapitalID] FOREIGN KEY([ShareCapitalID])
REFERENCES [dbo].[SHARECAPITAL] ([ShareCapitalID])
GO
ALTER TABLE [dbo].[SHARECAPITALTRANSACTION] CHECK CONSTRAINT [FK_ShareCapitalTransaction_ShareCapitalID]
GO
ALTER TABLE [dbo].[SHARECAPITALTRANSACTION]  WITH CHECK ADD  CONSTRAINT [FK_ShareCapitalTransaction_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[USER] ([UserID])
GO
ALTER TABLE [dbo].[SHARECAPITALTRANSACTION] CHECK CONSTRAINT [FK_ShareCapitalTransaction_UserID]
GO
ALTER TABLE [dbo].[TIMEDEPOSITACCOUNT]  WITH CHECK ADD  CONSTRAINT [FK_TimeDepositAccount_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[MEMBER] ([MemberID])
GO
ALTER TABLE [dbo].[TIMEDEPOSITACCOUNT] CHECK CONSTRAINT [FK_TimeDepositAccount_MemberID]
GO
ALTER TABLE [dbo].[TIMEDEPOSITACCOUNT]  WITH CHECK ADD  CONSTRAINT [FK_TimeDepositAccount_TimeDepositRatesID] FOREIGN KEY([TimeDepositRatesID])
REFERENCES [dbo].[TIMEDEPOSITRATES] ([TimeDepositRatesID])
GO
ALTER TABLE [dbo].[TIMEDEPOSITACCOUNT] CHECK CONSTRAINT [FK_TimeDepositAccount_TimeDepositRatesID]
GO
ALTER TABLE [dbo].[TIMEDEPOSITTRANSACTION]  WITH CHECK ADD  CONSTRAINT [FK_TimeDepositTransaction_TimeDepositAccountID] FOREIGN KEY([TimeDepositAccountID])
REFERENCES [dbo].[TIMEDEPOSITACCOUNT] ([TimeDepositAccountID])
GO
ALTER TABLE [dbo].[TIMEDEPOSITTRANSACTION] CHECK CONSTRAINT [FK_TimeDepositTransaction_TimeDepositAccountID]
GO
USE [master]
GO
ALTER DATABASE [SLSDB] SET  READ_WRITE 
GO
