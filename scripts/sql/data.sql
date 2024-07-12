USE ACDDatabase
GO

insert into BalanceServiceProvider(businessId , bspCode , bspName , codingScheme , country,ValidityStart,ValidityEnd  , Created, Active)
Values('986198113' ,'7080005010788' ,'Axpo Nordic AS' ,'GS1' ,'DK',GETDATE(),GETDATE() ,GETDATE() ,1)

GO
