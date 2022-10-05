create table FeedBackTable(
FeedbackId int Identity(1,1)primary key,
Comments varchar(max),
TotalRating float,
BookId int Foreign Key references BookInfo(BookId),
UserId int Foreign key references UserInfo(UserId)
)
select * from FeedBackTable
----Create StoreProcedure ------



 create  Proc spAddFeedback
(
	@Comment varchar(max),
	@TotalRating decimal,
	@BookId int,
	@UserId int
)
as
Declare @AverageRating int;
begin
	if (exists(SELECT * FROM FeedBackTable where BookId = @BookId and UserId=@UserId))
		select 1;
	Else
	Begin
		if (exists(SELECT * FROM Books WHERE BookId = @BookId))
		Begin  select * from FeedBackTable
			Begin try
				Begin transaction
					Insert into FeedBackTable(Comments, TotalRating, BookId, UserId) values(@Comment, @TotalRating, @BookId, @UserId);		
					set @AverageRating = (Select AVG(TotalRating) from FeedBackTable where BookId = @BookId);
					Update Books set TotalRating=@AverageRating where  BookId = @BookId;
				Commit Transaction
			End Try
			Begin catch
				Rollback transaction
			End catch
		End
		Else
		Begin
			Select 2; 
		End
	End
end;
---------GetFeedBack-----


create procedure spGetFeedback(
@BookId int
)  
As  
Begin try  
select FeedBackTable.Comments,FeedBackTable.FeedbackId,FeedBackTable.TotalRating,FeedBackTable.BookId,
Users.FullName
from FeedBackTable inner join Users on FeedBackTable.UserId=Users.UserId
where FeedBackTable.BookId=@BookId


end try  
Begin catch  
SELECT   
 ERROR_NUMBER() AS ErrorNumber,  
 ERROR_STATE() AS ErrorState,  
 ERROR_PROCEDURE() AS ErrorProcedure,  
 ERROR_LINE() AS ErrorLine,  
 ERROR_MESSAGE() AS ErrorMessage;  
END CATCH
