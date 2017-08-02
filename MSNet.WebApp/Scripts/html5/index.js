(function(){
//加载动画
document.onreadystatechange = loading; 

function loading(){
	if(document.readyState=="complete"){
		$('.loading').addClass('hide');
		//$(".home_pic_01").addClass('pt-page-moveCircle ');
		
		}		
	};
    //window.onload = function(){	}
$(".home_pic_01").click(function () {
    $("#home").addClass('pt-page-moveToTop');
    $(".page-1-1").addClass('pt-page-moveFromBottom page-current');
    $("#page1").removeClass('hide');
    $(".page-1-1").removeClass('hide');
    $(".btnnext2").addClass('hide');
    setTimeout(function () {
        $(".page-1-1").removeClass('pt-page-moveFromBottom');
        $("#home").addClass('hide');
        $(".btnnext2").removeClass('hide');
    }, 600);

});
$("#btnPage1").click(function () {
	$("#home").addClass('pt-page-moveToTop');
	$(".page-1-1").addClass('pt-page-moveFromBottom page-current');
	$("#page1").removeClass('hide');
	$(".page-1-1").removeClass('hide');
	$(".btnnext2").addClass('hide');
	setTimeout(function(){
		$(".page-1-1").removeClass('pt-page-moveFromBottom');
		$("#home").addClass('hide');
		$(".btnnext2").removeClass('hide');
	},600);
	
});
$("#btnPage2").click(function () {
    $("#page1").addClass('pt-page-moveToTop');
    $(".page-2-1").addClass('pt-page-moveFromBottom page-current');
    $("#page2").removeClass('hide');
    $(".page-2-1").removeClass('hide');
    $(".btnnext2").addClass('hide');
    setTimeout(function () {
        $(".page-2-1").removeClass('pt-page-moveFromBottom');
        $("#page1").addClass('hide');
        $(".btnnext2").removeClass('hide');
    }, 600);

});
//$("#btnPage3").click(function () {
//    window.location.reload();   
//});
//分页动画

//document.addEventListener('touchmove',function(event){
////	if (event && event.preventDefault) {
////	 	//alert("如果非ie下执行这个") ;
////      event.preventDefault();
////   }else{ 
////   	alert("如果是ie下执行这个") ;
////      window.event.returnValue = false;
////   }
//     if(-[1,]){ 
////		alert("这不是IE浏览器！"); 
//		event.preventDefault();
//	}else{ 
////		alert("这是IE浏览器！"); 
//		window.event.returnValue = false;
//	} 
//	//event.preventDefault(); 
//},false);



})();


		
