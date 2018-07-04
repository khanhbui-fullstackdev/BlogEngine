select	post.ID,post.Name,cate.Name [CateName],subcate.Name [SubName]
from	SubCategories subcate, Categories cate, Posts post
where	subcate.CategoryID=cate.ID and post.CategoryID=cate.ID