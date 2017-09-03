$(function(){
	var isIE=!!window.ActiveXObject;
	var isIE6=isIE&&!window.XMLHttpRequest;
    var isIE8=isIE&&!!document.documentMode;
    var isIE7=isIE&&!isIE6&&!isIE8;
	
	if(isIE6){
		var iestr = "<div id='kill_ie6' style='width:100%; height:40px; overflow:hidden; border-top:1px solid #dfd296; background:#fbf5b2; line-height:40px; font-size:12px; color:#ff6600; position:fixed; bottom:0px; left:0px; _position:absolute;_bottom:auto;_top:expression(eval(document.documentElement.scrollTop+document.documentElement.clientHeight-this.offsetHeight-(parseInt(this.currentStyle.marginTop,10)||0)-(parseInt(this.currentStyle.marginBottom,10)||0))); z-index:100;'>"
				  + "<span style='float:left; padding-left:20px;'>您使用的IE6浏览器无法完全支持本网站所有功能，建议使用升级为ie8以上或使用firefox、chrome浏览器浏览</span>"    
				  + "<a style='float:right; padding-right:20px; cursor:pointer;' id='kill_close'>关闭提示</a>"
				  + "</div>";
		$("body").append(iestr);
	}else if (isIE7){
		var iestr = "<div id='kill_ie6' style='width:100%; height:40px; overflow:hidden; border-top:1px solid #dfd296; background:#fbf5b2; line-height:40px; font-size:12px; color:#ff6600; position:fixed; bottom:0px; left:0px; _position:absolute;_bottom:auto;_top:expression(eval(document.documentElement.scrollTop+document.documentElement.clientHeight-this.offsetHeight-(parseInt(this.currentStyle.marginTop,10)||0)-(parseInt(this.currentStyle.marginBottom,10)||0))); z-index:100;'>"
				  + "<span style='float:left; padding-left:20px;'>您使用的IE7浏览器无法完全支持本网站所有功能，建议您升级为ie8以上ie浏览器或使用firefox、chrome浏览器浏览</span>"    
				  + "<a style='float:right; padding-right:20px; cursor:pointer;' id='kill_close'>关闭提示</a>"
				  + "</div>";
		$("body").append(iestr);
    }
	
	$("#kill_close").click(function(){
		$("#kill_ie6").css("display", "none");
	});
});
