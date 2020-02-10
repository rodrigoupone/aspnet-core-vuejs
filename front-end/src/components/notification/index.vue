<template>
  <li
    v-if="isVisible"
    class="nav-item dropdown"
    :class="{'show': isNotification, '': !isNotification }"
    @click="handleNotification"
  >
    <a
      class="nav-link dropdown-toggle text-muted text-muted"
      href="#"
      data-toggle="dropdown"
      aria-haspopup="true"
      aria-expanded="false"
    >
      <i class="fa fa-bell"></i>
      <div class="notify">
        <span class="heartbit"></span>
        <span class="point"></span>
      </div>
    </a>
    <div
      class="dropdown-menu dropdown-menu-right mailbox animated zoomIn"
      :class="{'show': isNotification, '': !isNotification }"
      @click="handleNotification"
    >
      <ul>
        <li>
          <div class="drop-title">Notificações</div>
        </li>
        <li>
          <div class="message-center">
            <!-- Message -->
            <a
              href="#"
              v-for="(item, index) in notifications"
              v-bind:key="index"
              @click.prevent="CheckRead(item.Id,index)"
            >
              <div class="btn btn-danger btn-circle m-r-10">
                <i class="fa fa-link"></i>
              </div>
              <div class="mail-contnet">
                <h5>{{item.Title}}</h5>
                <span class="mail-desc">{{item.Message}}</span>
                <span class="time">{{item.DateRegister | shortDateTime}}</span>
              </div>
            </a>
          </div>
        </li>
        <li>
          <a
            class="nav-link text-center"
            @click.prevent="CheckAllRead()"
            href="javascript:void(0);"
          >
            <strong>Marcar todas como lidas</strong>
            <i class="fa fa-angle-right"></i>
          </a>
        </li>
      </ul>
    </div>
  </li>
</template>
<script>
import { GetRest } from "../../api/Generic";
export default {
  data() {
    return {
      isNotification: false,
      isVisible: true,
      notifications: []
    };
  },
  mounted() {
    this.GetNotifications();
  },
  methods: {
    handleNotification(e) {
      this.isNotification = !this.isNotification;
    },
    async GetNotifications() {
      let response = await GetRest("Notification/GetMyNotifications", this);
      if (response.data.Status == 200) {
        this.isVisible = response.data.Data.length > 0;
        this.notifications = response.data.Data;
      } else {
        alert("erro");
        console.log(response);
      }
    },
    async CheckAllRead() {
      let response = await GetRest("Notification/CheckAllRead", this);
      if (response.data.Status == 200) {
        this.isVisible = response.data.Data.length > 0;
        this.handleNotification();
      } else {
        alert("erro");
        console.log(response);
      }
    },
    async CheckRead(id, index) {
      let response = await GetRest("Notification/CheckRead/" + id, this);
      if (response.data.Status == 200) {
        this.notifications.splice(index, 1);
        this.isVisible = this.notifications.length > 0;
        this.handleNotification();
      } else {
        alert("erro");
        console.log(response);
      }
    }
  }
};
</script>