CREATE TABLE [dbo].[UserInvestments] (
    [UserInvestmentId] INT             IDENTITY (1, 1) NOT NULL,
    [UserId]           INT             NOT NULL,
    [InvestmentId]     INT             NOT NULL,
    [Shares]           INT             NOT NULL,
    [CostBasis]   DECIMAL (19, 4) NOT NULL,
    [DatePurchased]    DATETIME        NOT NULL,
    CONSTRAINT [PK_UserInvestments] PRIMARY KEY CLUSTERED ([UserInvestmentId] ASC),
    CONSTRAINT [UK_UserInvestments] UNIQUE ([UserId], [InvestmentId]),
    CONSTRAINT [FK_UserInvestments_Investments] FOREIGN KEY ([InvestmentId]) REFERENCES [dbo].[Investments] ([InvestmentId]),
    CONSTRAINT [FK_UserInvestments_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[UserInvestments]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_InvestmentId]
    ON [dbo].[UserInvestments]([InvestmentId] ASC);

