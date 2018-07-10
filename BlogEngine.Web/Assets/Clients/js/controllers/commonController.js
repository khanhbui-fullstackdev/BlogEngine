var commonController = {
    init: function () {
        commonController.getPostsByKeyword();
        commonController.registerEvents();
    },
    registerEvents: function () {

    },
    getPostsByKeyword: function () {
        var categories;
        var typeHeadConfig = {
            input: '.js-typeahead',
            order: 'asc',
            minLength: 4,
            delay: 500,
            highlight: true,
            hint: true,
            maxItemPerGroup: 5,
            group: {
                template: "{{group}}"
            },
            template: function (query, item) {
                var postName = item.Name === null || item.Name === undefined ? '' : item.Name;
                var categoryName = (item.Category === null || item.Category === undefined) ? '</small></div>' : item.Category.Name;
                var templateHtml = "<div class='suggest-item post-suggestion'>" +
                    "<i class='fa fa-file-text-o' aria-hidden='true'></i> &nbsp;" + postName +
                    "<br />&nbsp; &nbsp; &nbsp; <small class='post-suggestion-text'> &nbsp;" + categoryName + "</small></div>";
                return templateHtml;
            },
            source: {
                'Posts': {
                    ajax: {
                        url: '/Home/GetPostsByKeyword',
                        type: 'POST',
                        dataType: "json",
                        data: { keyword: "{{query}}" },
                        path: 'Posts'
                    },
                    display: 'Name'
                },
                'Categories': {
                    ajax: {
                        url: '/Home/GetPostsByKeyword',
                        type: 'POST',
                        dataType: "json",
                        data: { keyword: "{{query}}" },
                        path: 'Categories'
                    },
                    display: 'Name'
                }
            },
            callback: {
                onClickBefore: function () { }
            }
        };

        $.typeahead(typeHeadConfig);
    }
};
commonController.init();//call itself