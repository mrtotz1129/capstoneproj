DROP DATABASE SLSDB
Go

USE SLSDB
Go

CREATE TABLE [USER]
(
	UserID int identity(1,1) not null,
	fName varchar(50) not null,
	mName varchar(50) null,
	lName varchar(50) not null,
	username varchar(50) not null,
	[password] varchar(50) not null,
	accountID int not null,
	securityQuestion varchar(100),
	securityAnswer varchar(100),
	[status] bit null,
	CONSTRAINT PK_UserID PRIMARY KEY (UserID)
)

INSERT INTO [USER] (fName, mName, lName, username, [password], accountID) VALUES ('Sir John Paul','Arguelles','Cutaran','admin','admin',1)
Go

CREATE TABLE COMPANY
(
	CompanyID int identity(1,1) not null,
	CompanyName varchar(50) null,
	street varchar(50) null,
	brgy varchar(50) null,
	city varchar(50) null,
	mobileNo varchar(10) null,
	mobileNoCountryCode varchar(15) null,
	teleNo varchar(10) null,
	teleNoCountryCode varchar(10) null,
	CONSTRAINT PK_CompanyID PRIMARY KEY (CompanyID)
)
Go

INSERT INTO COMPANY (CompanyName, street, brgy, city, mobileNo, mobileNoCountryCode, teleNo, teleNoCountryCode) VALUES ('Mandaluyong Trader''s Development Cooperative','807 Inocentes Street','Baranggay Pag-asa','Mandaluyong City','9999999999','+63','999-9999','')
Go

CREATE TABLE MEMBERTYPE
(
	MemberTypeID int identity(1,1) not null,
	MemberTypeName varchar(50) null,
	MinAgeRequired int null,
	MaxAgeRequired int null,
	Fee decimal null,
	SavingsApplicable bit null,
	TimeApplicable bit null,
	LoanApplicable bit null,
	ShareRequired decimal(18,2) null,
	[status] bit null,
	CONSTRAINT PK_MemberTypeID PRIMARY KEY (MemberTypeID)
)
Go

INSERT INTO MEMBERTYPE (MemberTypeName, MinAgeRequired, MaxAgeRequired, Fee, SavingsApplicable, TimeApplicable, LoanApplicable, ShareRequired, [status]) VALUES ('Regular Member','20','35','150','True','True','True','1500.00','True') , ('Associate Member','20','35','200','True','True','False','0.00','True')
Go 

CREATE TABLE SAVINGSTYPE
(
	SavingsTypeID int identity(1,1) not null,
	SavingsTypeName varchar(50) null,
	initialDeposit decimal(18,2) null,
	maintainingBalance decimal(18,2) null,
	balanceToEarn decimal(18,2) null,
	interestRate decimal(5,2) null,
	maxWithdrawAmount decimal(18,2) null,
	maxWithdrawMode int null,
	hasDormancy bit not null,
	[status] bit null,
	CONSTRAINT PK_SavingsTypeID PRIMARY KEY (SavingsTypeID)
)
Go

CREATE TABLE DORMANCY
(
	DormancyID int identity (1,1) not null,
	inactivityValue int null,
	inactivityTime int null,
	deductionAmount decimal(18,2) null,
	isPercentage int null,
	deductionMode  int null,
	activationFee decimal(18,2) null,
	[status] bit null,
	SavingsTypeID int not null,
	CONSTRAINT PK_DormancyID PRIMARY KEY (DormancyID),
	CONSTRAINT FK_Dormancy_SavingsTypeID FOREIGN KEY (SavingsTypeID) REFERENCES SAVINGSTYPE(SavingsTypeID)
)
Go

CREATE TABLE TIMEDEPOSITRATES
(
	TimeDepositRatesID int identity (1,1) not null,
	noOfDays int null,
	minAmount decimal(18,2) null,
	maxAmount decimal(18,2) null,
	interest decimal(18,2) null,
	[status] bit null,
	CONSTRAINT PK_TimeDepositRatesID PRIMARY KEY (TimeDepositRatesID)
)
Go

CREATE TABLE TIMEDEPOSITPENALTY
(
	TimeDepositPenaltyID int identity (1,1) not null,
	minElapsed decimal(5,2) null,
	maxElapsed decimal(5,2) null,
	reducedBy decimal(5,2) null,
	[status] bit null
	CONSTRAINT PK_TimeDepositPenaltyID PRIMARY KEY (TimeDepositPenaltyID)
)
Go

CREATE TABLE APPLICABLESAVINGS
(
	MemberTypeID int not null,
	SavingsTypeID int not null,
	CONSTRAINT FK_ApplicableSavings_MemberTypeID FOREIGN KEY (MemberTypeID) REFERENCES MEMBERTYPE(MemberTypeID),
	CONSTRAINT FK_ApplicableSavings_SavingsTypeID FOREIGN KEY (SavingsTypeID) REFERENCES SAVINGSTYPE (SavingsTypeID)
)
Go

CREATE TABLE MEMBER
(
	MemberID int identity(1,1) not null,
	fName varchar(50) not null,
	mName varchar(50) not null,
	lName varchar(50) not null,
	gender bit null,
	birthDate date null,
	civilStatus varchar(10) null,
	gsisNo varchar(50) null,
	educAttainment int null,
	paidMembershipFee decimal (9,2) null,
	applyDate date null,
	seminarDate date null,
	initialCapital decimal (9,2) null,
	multiplier int null,
	isActive bit null,
	MemberTypeID int null,
	CONSTRAINT PK_MemberID PRIMARY KEY (MemberID),
	CONSTRAINT FK_Member_MemberTypeID FOREIGN KEY (MemberTypeID) REFERENCES MEMBERTYPE (MemberTypeID)
)
Go
		
--INSERT INTO MEMBER(fName, mName, lName, birthDate, MemberTypeID) VALUES ('Sir John Paul','Arguelles','Cutaran','1994-12-11','1'), ('Kenneth','','Avecilla','1996-07-15','1')
--Go

CREATE TABLE CONTACTINFORMATION
(	
AddressID int identity (1,1) not null,
street varchar(25) NULL,
municipality varchar(25) NULL,
cityProvince varchar(25) NULL,
zipCode int NUll,
residenceSince varchar(25) NULL,
telephoneNo int NULL,
MemberID int not null,
CONSTRAINT PK_AddressID PRIMARY KEY (AddressID),
CONSTRAINT FK_address_MemberID FOREIGN KEY (MemberID) REFERENCES MEMBER (MemberID)
)
Go

CREATE TABLE CONTACTPERSON
(
contactID int identity (1,1) not null,
contactFN varchar(25) NULL,
contactLN varchar(25) NULL,
contactMN varchar(25) NULL,
contactNo varchar(25) NULL,
MemberID int not null,
CONSTRAINT PK_contactID PRIMARY KEY (contactID),
CONSTRAINT FK_contact_MemberID FOREIGN KEY (MemberID) REFERENCES MEMBER (MemberID)
)
Go

CREATE TABLE EMPLOYMENTINFORMATION
(
	EmploymentInformationID int identity(1,1) not null,
	employmentNo int not null,
	MemberID int not null,
	CONSTRAINT PK_EmploymentInformationID PRIMARY KEY (EmploymentInformationID),
	CONSTRAINT FK_EmploymentInformation_MemberID FOREIGN KEY (MemberID) REFERENCES MEMBER (MemberID)
)
Go
CREATE TABLE EMPLOYED
(
	EmployedID int identity(1,1) not null,
	employerName varchar(50) not null,
	employerAddress varchar(50) not null,
	employerType int not null,
	employerTelNo varchar(7) not null,
	dateStarted date not null,
	monthlySalary decimal not null,
	department varchar(50) not null,
	EmploymentInformationID int not null,
	CONSTRAINT PK_EmployedID PRIMARY KEY (EmployedID),
	CONSTRAINT FK_Employed_EmploymentInformationID FOREIGN KEY (EmploymentInformationID) REFERENCES EMPLOYMENTINFORMATION (EmploymentInformationID)
)
Go
CREATE TABLE SELFEMPLOYED
(
	SelfEmployedID int identity(1,1) not null,
	typeOfBusiness varchar(50) not null,
	startingCapital decimal (9,2) not null,
	monthlyNetIncome money not null,
	businessAddress varchar(50) not null,
	presentCapital money not null,
	EmploymentInformationID int not null,
	CONSTRAINT PK_SelfEmployedID PRIMARY KEY (SelfEmployedID),
	CONSTRAINT FK_SelfEmployed_EmploymentInformationID FOREIGN KEY (EmploymentInformationID) REFERENCES EMPLOYMENTINFORMATION (EmploymentInformationID)
)
Go
CREATE TABLE FAMILYBACKGROUND
(
	FamilyID int identity (1,1) not null,
	fName varchar(50) not null,
	mName varchar(50) not null,
	lName varchar(50) not null,
	birthDate date not null,
	gender bit not null,
	relationship varchar(50) not null,
	MemberID int not null,
	CONSTRAINT PK_FamilyID PRIMARY KEY (FamilyID),
	CONSTRAINT FK_Family_MemberID FOREIGN KEY (MemberID) REFERENCES MEMBER (MemberID)
)
Go
CREATE TABLE SHARECAPITAL
(
	ShareCapitalID int identity (1,1) not null,
	MemberID int not null,
	currentBalance money not null,
	multiplier int not null,
	CONSTRAINT PK_ShareCapitalNo PRIMARY KEY (ShareCapitalID),
	CONSTRAINT FK_ShareCapital_MemberID FOREIGN KEY (MemberID) REFERENCES MEMBER (MemberID)
)
Go
CREATE TABLE SHARECAPITALTRANSACTION
(
	TransactionID int identity (1,1) not null,
	transactionDatetime date not null,
	transactionType varchar(50) not null,
	amount money not null,
	currentBalance money not null,
	ShareCapitalID int not null,
	UserID int not null,
	CONSTRAINT PK_ShareCapitalTransactionID PRIMARY KEY (TransactionID),
	CONSTRAINT FK_ShareCapitalTransaction_ShareCapitalID FOREIGN KEY (ShareCapitalID) REFERENCES SHARECAPITAL (ShareCapitalID),
	CONSTRAINT FK_ShareCapitalTransaction_UserID FOREIGN KEY (UserID) REFERENCES [USER] (UserID)
)
Go

CREATE TABLE SAVINGSACCOUNT
(
	SavingsAccountID int identity(1,1) not null,
	MemberID int not null,
	SavingsTypeID int not null,
	dateOpened date null,
	dateClosed date null,
	currentBalance decimal(18,2) null,
	CONSTRAINT PK_SavingsAccountID PRIMARY KEY (SavingsAccountID),
	CONSTRAINT FK_SavingsAccount_MemberID FOREIGN KEY (MemberID) REFERENCES MEMBER(MemberID),
	CONSTRAINT FK_SavingsAccount_SavingsTypeID FOREIGN KEY (SavingsTypeID) REFERENCES SAVINGSTYPE(SavingsTypeID),
)
Go

CREATE TABLE SAVINGSTRANSACTION
(
	SavingsTransactionID int identity(1,1) not null,
	transactionDate date null,
	transactionType varchar(50) null,
	transactionAmount decimal(18,2) null,
	transactionRepresentative varchar(100) null,
	currentBalance decimal(18,2) null,
	SavingsAccountID int not null,
	CONSTRAINT PK_SavingsTransactionID PRIMARY KEY (SavingsTransactionID),
	CONSTRAINT FK_SavingsTransaction_SavingsAccountID FOREIGN KEY (SavingsAccountID) REFERENCES SAVINGSACCOUNT(SavingsAccountID)
)
Go

CREATE TABLE TIMEDEPOSITACCOUNT
(
	TimeDepositAccountID int identity(1,1) not null,
	MemberID int not null,
	TimeDepositRatesID int not null,
	dateOpened date null,
	dateMaturity date null,
	dateClosed date null,
	currentBalance decimal(18,2) null,
	isClosed bit null,
	CONSTRAINT PK_TimeDepositAccountID PRIMARY KEY (TimeDepositAccountID),
	CONSTRAINT FK_TimeDepositAccount_MemberID FOREIGN KEY (MemberID) REFERENCES MEMBER(MemberID),
	CONSTRAINT FK_TimeDepositAccount_TimeDepositRatesID FOREIGN KEY (TimeDepositRatesID) REFERENCES TIMEDEPOSITRATES(TimeDepositRatesID)
)
Go

CREATE TABLE TIMEDEPOSITTRANSACTION
(
	TimeDepositTransactionID int identity(1,1) not null,
	transactionDate date null,
	transactionType varchar(50) null,
	transactionAmount decimal(18,2) null,
	transactionRepresentative varchar(100) null,
	TimeDepositAccountID int not null,
	CONSTRAINT PK_TimeDepositTransactionID PRIMARY KEY (TimeDepositTransactionID),
	CONSTRAINT FK_TimeDepositTransaction_TimeDepositAccountID FOREIGN KEY (TimeDepositAccountID) REFERENCES TIMEDEPOSITACCOUNT(TimeDepositAccountID)
)
Go
		
CREATE TABLE CHARGES
(
	ChargeID int identity (1,1) not null,
	chargeName varchar(50) not null,
	[status] bit null,
	CONSTRAINT PK_ChargeID PRIMARY KEY (ChargeID)
)
Go
CREATE TABLE TERM
(
	TermID int identity (1,1) not null,
	noOfDays int not null,
	[status] bit null,
	CONSTRAINT PK_TermID PRIMARY KEY (TermID)
)
Go
CREATE TABLE MODE
(
	ModeID int identity (1,1) not null,
	modeName varchar(50) not null,
	daysInterval int not null,
	[status] bit null,
	CONSTRAINT PK_ModeID PRIMARY KEY (ModeID)
)
Go
CREATE TABLE CREDITINVESTIGATOR
(
	ciID int identity(1,1) not null,
	fName varchar(50) not null,
	mName varchar(50) null,
	lName varchar(50) not null,
	[status] bit null,
	CONSTRAINT PK_ciID PRIMARY KEY (ciID)
)
Go
CREATE TABLE LOANGRANTOR
(
	lgID int identity(1,1) not null,
	fName varchar(50) not null,
	mName varchar(50) null,
	lName varchar(50) not null,
	position varchar(50) not null,
	[status] bit null,
	CONSTRAINT PK_lgID PRIMARY KEY (lgID)
)
Go
CREATE TABLE LOANTYPE
(
	LoanTypeID int identity(1,1) not null,
	loanTypeName varchar(50) null,
	minAmount money null,
	maxAmount money null,
	noOfComaker int null,
	entitlement decimal null,
	eligibility decimal null,
	[status] bit null,
	CONSTRAINT PK_LoanTypeID PRIMARY KEY (LoanTypeID)
)

CREATE TABLE APPLICABLELOAN
(
	LoanTypeID int not null,
	MemberTypeID int not null,
	CONSTRAINT FK_ApplicableLoan_LoanTypeID FOREIGN KEY (LoanTypeID) REFERENCES LOANTYPE(LoanTypeID),
	CONSTRAINT FK_ApplicableLoan_MemberTypeID FOREIGN KEY (MemberTypeID) REFERENCES MEMBERTYPE(MemberTypeID)
)

CREATE TABLE LOANRATE
(
	ModeID int not null,
	ChargeID int not null,
	TermID int not null,
	LoanTypeID int not null,
	rate decimal not null,
	CONSTRAINT FK_Rate_ModeID FOREIGN KEY (ModeID) REFERENCES MODE(ModeID),
	CONSTRAINT FK_Rate_ChargeID FOREIGN KEY (ChargeID) REFERENCES CHARGES(ChargeID),
	CONSTRAINT FK_Rate_TermID FOREIGN KEY (TermID) REFERENCES TERM(TermID),
	CONSTRAINT FK_Rate_LoanTypeID FOREIGN KEY (LoanTypeID) REFERENCES LOANTYPE(LoanTypeID)
)

CREATE TABLE LOAN
(
	LoanID int identity (1,1) not null,
	LoanTypeID int not null,
	applyAmount money not null,
	TermID int not null,
	ModeID int not null,
	dateApplied date not null,
	isApproved bit not null,
	MemberID int not null,
	reason varchar(150) not null,
	CONSTRAINT PK_LoanID PRIMARY KEY (LoanID),
	CONSTRAINT FK_Loan_LoanTypeID FOREIGN KEY (LoanTypeID) REFERENCES LOANTYPE (LoanTypeID),
	CONSTRAINT FK_Loan_TermID FOREIGN KEY (TermID) REFERENCES TERM (TermID),
	CONSTRAINT FK_Loan_ModeID FOREIGN KEY (ModeID) REFERENCES MODE(ModeID),
	CONSTRAINT FK_Loan_MemberID FOREIGN KEY (MemberID) REFERENCES MEMBER (MemberID)
)
Go

CREATE TABLE GRANTEDLOAN
(
	GrantedLoanID int identity (1,1) not null,
	grantedDate date not null,
	grantedAmount decimal (9,2) not null,
	remarks varchar(150) not null,
	LoanID int not null,
	CONSTRAINT PK_GrantedLoanID PRIMARY KEY (GrantedLoanID),
	CONSTRAINT FK_GrantedLoan_LoanID FOREIGN KEY (LoanID) REFERENCES LOAN (LoanID)
)
Go
CREATE TABLE GRANTER
(
	GranterID int identity (1,1) not null,
	LName varchar(50) not null,
	FName varchar(50) not null,
	MName varchar(50) not null,
	position varchar(50) not null,
	CONSTRAINT PK_GranterID PRIMARY KEY (GranterID),
)
Go
CREATE TABLE GRANTEDBY
(
	GrantedByID int identity (1,1) not null,
	GrantedLoanID int not null,
	GranterID int not null,
	CONSTRAINT PK_GrantedByID PRIMARY KEY (GrantedByID),
	CONSTRAINT FK_GrantedBy_GrantedLoanID FOREIGN KEY (GrantedLoanID) REFERENCES GRANTEDLOAN (GrantedLoanID),
	CONSTRAINT FK_GrantedBy_GranterID FOREIGN KEY (GranterID) REFERENCES GRANTER (GranterID)
)
Go
CREATE TABLE COMAKER
(
	ComakerID int identity (1,1) not null,
	MemberID int not null,
	CONSTRAINT PK_ComakerID PRIMARY KEY (ComakerID),
	CONSTRAINT FK_Comaker_MemberID FOREIGN KEY (MemberID) REFERENCES MEMBER (MemberID)
)
Go
CREATE TABLE REBATE
(
	RebateID int identity (1,1) not null,
	rebateAmount decimal (9,2) not null,
	isWithdrawn bit not null,
	MemberID int not null,
	CONSTRAINT PK_RebateID PRIMARY KEY (RebateID),
	CONSTRAINT FK_MemberID FOREIGN KEY (MemberID) REFERENCES MEMBER(MemberID)
)
Go
CREATE TABLE LOANTRANSACTION
(
	TransactionID int identity (1,1) not null,
	transactionDatetime date not null,
	transactionType varchar(50) not null,
	amount money not null,
	currentBalance money not null,
	LoanID int not null,
	UserID int not null,
	CONSTRAINT PK_LoanTransactionID PRIMARY KEY (TransactionID),
	CONSTRAINT FK_LoanTransaction_LoanID FOREIGN KEY (LoanID) REFERENCES LOAN (LoanID),
	CONSTRAINT FK_LoanTransaction_UserID FOREIGN KEY (UserID) REFERENCES [USER] (UserID)
)
Go
CREATE TABLE AUDITTRAIL
(
	AuditID int identity (1,1) not null,
	activity varchar(50) not null,
	activityDatetime date not null,
	UserID int not null,
	CONSTRAINT PK_AuditID PRIMARY KEY (AuditID),
	CONSTRAINT FK_audittrailUserID FOREIGN KEY (UserID) REFERENCES [USER](UserID)
)
Go