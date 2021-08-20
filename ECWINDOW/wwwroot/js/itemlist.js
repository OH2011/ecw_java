$(function(){
	$("#item_category_dropdown").click(function(){
		if($("#item_category_dropdown_list").css("display") == "none"){
			$("#item_category_dropdown").addClass("open");
			$("#item_category_dropdown_list").slideDown({duration: 16});
		}else{
			$("#item_category_dropdown").removeClass("open");
			$("#item_category_dropdown_list").slideUp({duration: 16});
		}
	});
});

$(window).resize(function() {
	$("#item_category_dropdown").removeClass("open");
	$("#item_category_dropdown_list").css("display", "none");
});

// 検索窓から検索実行
function search(){
	$("#execSearch").submit();
}

// カテゴリ選択から検索実行
function searchByCategory(c1, c2){
	console.log(c1,c2);
	$("#hid_c1").val(c1);
	$("#hid_c2").val(c2);
	$("#execSearchByCategory").submit();
}

// ページング
function paging(c1, c2, k, min, max, page){
	$("#hid_p_c1").val(c1);
	$("#hid_p_c2").val(c2);
	$("#hid_p_k").val(k);
	$("#hid_p_min").val(min);
	$("#hid_p_max").val(max);
	$("#hid_p_page").val(page);
	$("#execPaging").submit();
}

$(function(){
	// 数字とキャレット移動、backspace、delete、Tab以外は受け付けない
	$("#min_text").keydown(function(event){
		if(isNaN(event.key) && event.keyCode != 8 && event.keyCode != 9 && event.keyCode != 46 && event.keyCode != 37 && event.keyCode != 39)return false;
	});
	// ↑の処理だとIME入力は制御できないのでフォーカスが外れた時にまとめて処理する
	$("#min_text").focusout(function(){
		this.value = this.value.replace(/[^0-9]+/i,'');
		$("#hid_min").val($(this).val());
	});

	// 下限BOXと同じ
	$("#max_text").keydown(function(event){
		if(isNaN(event.key) && event.keyCode != 8 && event.keyCode != 9 && event.keyCode != 46 && event.keyCode != 37 && event.keyCode != 39)return false;
	});
	$("#max_text").focusout(function(){
		this.value = this.value.replace(/[^0-9]+/i,'');
		$("#hid_max").val($(this).val());
	});
});

// 価格帯検索実行
function searchByPrice(){
	$("#hid_min").val($("#min_text").val());
	$("#hid_max").val($("#max_text").val());
	$("#execSearchByPrice").submit();
}

// 商品一覧クリック時
function onClickItem(item_cd){
	console.log(item_cd);
	$("#hid_detail_cd").val(item_cd);
	$("#execDetail").submit();
}

// バナークリック時
function onClickBanner(banner_id){
	if(banner_id == "3"){
		$("#hid_c1").val("10");
		$("#hid_c2").val("30");
		$("#search").submit();
	}else{
		$("#top").submit();
	}
}

// スライドクリック時
function onClickSlide(slide_id){
	if(slide_id == "1"){
		$("#hid_c1").val("30");
		$("#hid_c2").val("20");
		$("#execSearchByCategory").submit();
	}else if(slide_id == "2"){
		$("#hid_slide_cd").val("0000001002");
		$("#execSlideDetail").submit();
	}else if(slide_id == "3"){
		$("#hid_c1").val("20");
		$("#hid_c2").val("10");
		$("#execSearchByCategory").submit();
	}
}


function loadSlider(){
    $('.bxslider').bxSlider({
	auto: true,
    autoControls: true,
    stopAutoOnClick: true,
    pager: true,
	touchEnabled:false,

    slideWidth: 1000
  });
}



