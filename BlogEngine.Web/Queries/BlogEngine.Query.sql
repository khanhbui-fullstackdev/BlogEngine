select	post.ID,post.Name,cate.Name [CateName],subcate.Name [SubName],subcate.ID [SubId]
from	SubCategories subcate, Categories cate, Posts post
where	subcate.CategoryID=cate.ID and post.CategoryID=cate.ID


select	post.Name [PostName],
		cate.Name[CateName],
		cate.ID [CateId],
		subCate.Name[SubCateName],
		subCate.ID [SubId]
from	SubCategories subcate, Posts post, Categories cate
where	subcate.ID=10	and 
		cate.ID=6		and
		post.CategoryID = cate.ID and
		subcate.CategoryID = cate.ID
