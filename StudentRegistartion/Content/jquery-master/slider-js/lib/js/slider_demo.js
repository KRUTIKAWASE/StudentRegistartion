  $(function(){
    //新建一个Slider对象实例，并且设置幻灯持续间隔为3000毫秒
    var slider = new Slider("#slider").setDuration(3000);
	//设置幻灯片的大小
    slider.setSize(600, 400);
	//从photos.json这个本地的json文件中加载幻灯片图像
    slider.fetchJson('photos.json');
	//定义一个转场数组
    var transitions = ['transition-opacity', 'transition-simplel', 'transition-zoomin','transition-flip', 'transition-cardflip', 
    'transition-rotatezoomin','transition-rotatezoomout', 'transition-topfade', 'transition-skewflip','transition-left','transition-top','transition-oblique','circles','squares', 'circle',
    'verticalOpen', 'diamond','verticalSunblind',	'horizontalOpen', 'clock','horizontalSunblind']
	//使用setInterval定时设置每隔5555毫秒随机更改转场效果
    setInterval(function(){
	  //随机获取转场效果名称
      var transition = transitions[Math.floor(Math.random()*transitions.length)];	  
      if(SliderTransitionFunctions[transition]){ 	
        //设置Canvas转场效果
        slider.setTransitionFunction(SliderTransitionFunctions[transition])
		//设置CSS转场效果
       } else slider.setTransition(transition);
    }, 5000);
	

  });
  