<template>
  <v-row justify="center" align="center">
    <v-btn
      depressed
      color="primary"
      @click="getNoneigOrders"
    >
      Primary
    </v-btn>
    <v-data-table
        :headers="headers"
        :items="items"
        :loading="loading"
        disable-sort
        dense
      />
  </v-row>
</template>

<script>
export default {
  data() {
    return {
      items: [],
      loading: false,
      headers: [
        { text: 'data', value: 'id' },
        { text: 'data', value: 'username' },
        { text: 'data', value: 'password' }
      ],
      selectedFilters: {},
      tasksFrom: null,
      tasksTo: null,
      tab: 0,

      uniqueManagers: [],
    }
  },
  created() {
    this.getNoneigOrders()
  },
  methods: {
    async getNoneigOrders() {
      this.loading = true
      this.items = await this.$axios.$get(
        'https://localhost:7292/pimpis/users'
      );
      this.loading = false
      //console.log(this.items)
    },
  },
}
</script>
