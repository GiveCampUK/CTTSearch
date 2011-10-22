!function() {
	
	this.CTT = {

		views: [
			['/$', {
				init: function() {

					this.domOrgSize = $('#f_org_size');
					this.domTechLevel = $('#f_user_proficiency');

					this.domOrgSizeValueLabel = $('<span/>').appendTo('label[for=f_org_size]');
					this.domTechLevelValueLabel = $('<span/>').appendTo('label[for=f_user_proficiency]');

					this.orgSizeSlider = $('<div class="slider"/>')
						.insertAfter(this.domOrgSize).slider({
							value: 0,
							min: 0,
							max: 500,
							step: 50,
							slide:  function(e, ui){
								this.domOrgSizeValueLabel.text(' (' + ui.value + ')');
							}.bind(this)
						})
						.data('slider');

					this.techLevelSlider = $('<div class="slider"/>')
						.insertAfter(this.domTechLevel).slider({
							value: 0,
							min: 0,
							max: 1.5,
							step: .5,
							slide: function(e, ui){
								this.domTechLevelValueLabel.text(
									this.convertTechLevelSliderVal(ui.value)
								);
							}.bind(this)
						})
						.data('slider');

					this.domOrgSize.hide();
					this.domTechLevel.hide();

					this.orgSizeSlider.options.slide(null, {value:0});
					this.techLevelSlider.options.slide(null, {value:0});

				},
				techLevelSliderValues: {
					
				},
				convertTechLevelSliderVal: function(v) {
					
				}
			}]
		],

		init: function() {

			var loc = window.location.pathname,
				viewHandlers = this.views;

			for (var i = -1, l = viewHandlers.length; ++i < l;) {
				if ( RegExp(viewHandlers[i][0]).test(loc) ) {
					viewHandlers[i][1].CTT = this;
					viewHandlers[i][1].init();
				}
			}

		}

	};

	Function.prototype.bind = Function.prototype.bind || function(b) {
		var f = this;
		return function() {
			return f.apply(b, arguments);
		}	;
	};

}();