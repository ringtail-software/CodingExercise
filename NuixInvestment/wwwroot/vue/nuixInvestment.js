(function () {
	'use strict';

	Vue.config.devtools = true;
	Vue.use(VueRouter);

	const router = new VueRouter({
		mode: 'history'
	});

	const nuix = new Vue({
		router: router,
		data: {
			userId: '',
			investments: [],
			details: [],
			sortKey: 'InvestmentId',
			sortOrder: 1,
			page: {
				currentPage: 1
			},
			pageSize: 8,
			message: 'Loading... If this message persists check your API connection'
		},
		created() {
			this.userId = document.title.replace('NuixInvestment - ', '');
			this.getUserInvestments(this.userId);
		},
		methods: {
			sort: function (s) {
				if (s === this.sortKey) {
					this.sortOrder = -1 * this.sortOrder;
				}
				this.sortKey = s;
				this.page.currentPage = 1;
			},
			getUserInvestments: function (userId) {
				axios.get('/api/Investments/' + userId).then((response) => {
					this.investments = response.data;
				})
				//axios.get('https://localhost:5011/api/Investments/' + userId).then((response) => {
				//	this.investments = response.data;
				//})
			},
			getInvestmentDetail: function (userId) {
				axios.get('/api/details/' + userId).then((response) => {
					this.details = response.data;
				})
				//router.push({
				//	path: '/Detail'
				//});
			}
		}
	}).$mount('#nuixinvestment');

	Vue.filter('dateTime', function (value) {
		if (value) {
			return moment(String(value)).format('MM/DD/YYYY');
		}
	});

	Vue.directive('arrow', {
		bind: function (el, binding) {
			el.style.color = 'dodgerblue';

			if (nuix.sortKey === binding.value.sortKey) {
				if (nuix.sortOrder === 1) {
					el.innerHTML = '▴';
				} else {
					el.innerHTML = '▾';
				}
			} else {
				el.innerHTML = '';
			}
		},
		update: function (el, binding) {
			if (nuix.sortKey === binding.value.sortKey) {
				if (nuix.sortOrder === 1) {
					el.innerHTML = '▴';
				} else {
					el.innerHTML = '▾';
				}
			} else {
				el.innerHTML = '';
			}
		}
	});
})();