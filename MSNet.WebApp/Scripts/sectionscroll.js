$(function() {
    // price
      scrollPage(); 
     $body = (window.opera) ? (document.compatMode == "CSS1Compat" ? $('html') : $('body')) : $('html,body');    
	
});


function scrollPage(){
  var currentSectionIndex = 0;
  var isScrolling = false;
  var sectionList = $('.section');
  var sectionCount = sectionList.length;
  var highlightedSection = 0;
  //全局section个数
  navList = sectionCount;
  function highlightSection(i){
    $('.sectionWrapper').removeClass('fadeInDown');
    $(sectionList[i]).find('.sectionWrapper').addClass('fadeInDown');
  }
  function adjustCurrentSectionIndex() {
        var $w = $(window);
        var winScrollTop = $w.scrollTop();
        var winHeight = $w.height();  		
        var viewTop = $w.scrollTop(),
            viewBottom = viewTop + $w.height();
        for(var i = 0; i < sectionCount; i++) {
          var section = $(sectionList[i]);
          var sectionTop = section.offset().top;
          var sectionHeight = section.height();
          var sectionBottom = sectionTop + sectionHeight;
          if(winScrollTop <=  (sectionTop + sectionHeight) && winScrollTop > (sectionTop + sectionHeight*9/10)) {
            highlightedSection=i+1;
            highlightSection(highlightedSection);
            currentSectionIndex = highlightedSection;           
          }else{
          	highlightedSection = i;
          }          
          if((sectionBottom <= viewBottom) && (sectionTop >= viewTop)) {
            currentSectionIndex = i;
            break;
          }
        }
      }
  adjustCurrentSectionIndex();
  var ele;
  $(window).on('scroll', function(){
    adjustCurrentSectionIndex();	 
    //if (currentSectionIndex == 0) {
    //  currentSectionIndex = 1;
    //};
    ele=sectionList[currentSectionIndex];
    $(ele).find('.sectionWrapper').addClass('fadeInDown');
    $(this).resize(function(){
      if(ele){
          scrollTo(ele);
      }
    });
  })

  function scrollTo(ele) {
    $('.sectionWrapper').removeClass('fadeInDown');
    isScrolling = true;
    $('html,body').stop().animate({
      scrollTop: $(ele).offset().top
    }, 1000, function(){
      isScrolling = false;
      $(ele).find('.sectionWrapper').addClass('fadeInDown');
    });
  }

  $('body').on('mousewheel', function(e){
    e.preventDefault();
    if(!isScrolling) {
      var deltaY = e.deltaY;
      switch(deltaY){
        case 1:
        currentSectionIndex -= 1;
        if (currentSectionIndex < 0) {
           
          currentSectionIndex = 0;
        } else {
           
          scrollTo(sectionList[currentSectionIndex]);
        }
        break;
        case -1:
        currentSectionIndex += 1;
        if(currentSectionIndex > sectionCount - 1) {
          currentSectionIndex = sectionCount - 1;
        } else {            
          scrollTo(sectionList[currentSectionIndex]);
        }
        break;
        default:
        break;
      }
    }
  });
}