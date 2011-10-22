// Yo, JS.

!function() {
	
	this.CTT = {

		views: [
			['/$', {

				init: function() {

					// Setup sliders

					this.domOrgSize = $('#f_org_size');
					this.domTechLevel = $('#f_user_proficiency');

					this.domOrgSizeValueLabel = $('<span/>').appendTo('label[for=f_org_size]');
					this.domTechLevelValueLabel = $('<span/>').appendTo('label[for=f_user_proficiency]');

					this.orgSizeSlider = $('<div class="slider"/>')
						.insertAfter(this.domOrgSize).slider({
							value: 0,
							min: 1,
							max: 3,
							step: 1,
							slide:  function(e, ui){
								var val = this.convertOrgSizeSliderVal(ui.value) ;
								this.domOrgSizeValueLabel.text(' (' + val + ')');
								this.domOrgSize.val(val);
							}.bind(this)
						})
						.data('slider');

					this.techLevelSlider = $('<div class="slider"/>')
						.insertAfter(this.domTechLevel).slider({
							value: 0,
							min: 1,
							max: 3,
							step: 1,
							slide: function(e, ui) {
								var val = this.convertTechLevelSliderVal(ui.value) ;
								this.domTechLevelValueLabel.text(' (' + val + ')');
								this.domTechLevel.val(val);
							}.bind(this)
						})
						.data('slider');

					this.domOrgSize.hide();
					this.domTechLevel.hide();

					this.orgSizeSlider.options.slide(null, {value:1});
					this.techLevelSlider.options.slide(null, {value:1});

				},

				convertOrgSizeSliderVal: function(v) {
					switch (v) {
						case 1: return '1-5'
						case 2: return '6-25'
						case 3: return '26+'
					}
				},
				
				convertTechLevelSliderVal: function(v) {
					switch (v) {
						case 1: return 'Novice'
						case 2: return 'Intermediate'
						case 3: return 'Advanced'
					}
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