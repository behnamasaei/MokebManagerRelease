import { Component, ViewEncapsulation } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { EntryExitZaerService, MokebService } from '@proxy';
import { MokebDto } from '@proxy/domain/dtos';
import { Title } from '@angular/platform-browser';
import { DateAdapter } from '@angular/material/core';
import { enUS, faIR } from 'date-fns/locale';

@Component({
  selector: 'app-reporting',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './reporting.component.html',
  styleUrl: './reporting.component.scss',
  encapsulation: ViewEncapsulation.Emulated,
})
export class ReportingComponent {
  startDate: any;
  endDate: any;
  rangeDates: any;
  mokebData: any;
  mokebFreeCapacityData: any;
  mokebReserveInRangeData: any;

  basicOptions: any;

  mokebName: string[] = [];
  mokebCapacity: number[] = [];

  mokebFreeNightName: string[] = [];
  mokebFreeNightCapacity: number[] = [];

  mokebReservsionNightName: string[] = [];
  mokebReservsionNightCapacity: number[] = [];

  mokebReserveInRangeDataName: string[] = [];
  mokebReserveInRangeDataCapacity: number[] = [];
  /**
   *
   */
  constructor(
    private mokebService: MokebService,
    private entryExitService: EntryExitZaerService,
    private titleService: Title,
    private _adapter: DateAdapter<any>
  ) {}

  ngOnInit() {
    this._adapter.setLocale(faIR);
    this.titleService.setTitle('مدیریت موکب | گزارشگیری');
    const documentStyle = getComputedStyle(document.documentElement);
    const textColor = documentStyle.getPropertyValue('--text-color');
    const textColorSecondary = documentStyle.getPropertyValue('--text-color-secondary');
    const surfaceBorder = documentStyle.getPropertyValue('--surface-border');

    this.mokebService.getMokebFreeCapacityToNight().subscribe(mokeb => {
      mokeb.forEach(item => {
        this.mokebFreeNightName.push(item.mokeb.name);
        this.mokebFreeNightCapacity.push(item.freeCapacityToNight);

        this.mokebReservsionNightName.push(item.mokeb.name);
        this.mokebReservsionNightCapacity.push(item.mokeb.capacity - item.freeCapacityToNight);
      });

      const backgroundColor = this.mokebFreeNightName.map(() => this.getRandomColor(1));
      const borderColor = this.mokebReservsionNightName.map(() => this.getRandomColor());

      this.mokebFreeCapacityData = {
        labels: this.mokebFreeNightName,
        datasets: [
          {
            label: 'ظرفیت خالی امشب موکب ها',
            data: this.mokebFreeNightCapacity,
            backgroundColor: backgroundColor,
            borderColor: borderColor,
            borderWidth: 1,
          },
        ],
      };

      this.mokebData = {
        labels: this.mokebReservsionNightName,
        datasets: [
          {
            label: 'تعداد پذیرش های امشب هر موکب',
            data: this.mokebReservsionNightCapacity,
            backgroundColor: backgroundColor,
            borderColor: borderColor,
            borderWidth: 1,
          },
        ],
      };
    });

    // this.mokebService.getAllList().subscribe(mokeb => {
    //   mokeb.items.forEach(item => {
    //     this.mokebName.push(item.name);
    //     this.mokebCapacity.push(item.capacity);
    //   });

    // });

    this.basicOptions = {
      plugins: {
        legend: {
          labels: {
            color: textColor,
            font: {
              size: 18, // Set font size for legend labels
            },
            title: {
              display: true,
              font: {
                size: 22, // Set font size for the chart title
              },
            },
          },
        },
      },
      scales: {
        y: {
          beginAtZero: true,
          ticks: {
            color: textColorSecondary,
            font: {
              size: 14, // Set font size for Y axis labels
            },
          },
          grid: {
            color: surfaceBorder,
            drawBorder: false,
          },
        },
        x: {
          ticks: {
            color: textColorSecondary,
            font: {
              size: 20, // Set font size for Y axis labels
            },
          },
          grid: {
            color: surfaceBorder,
            drawBorder: false,
          },
        },
      },
    };
  }

  searchInRangeDate() {
    // if (!this.rangeDates) return;

    const mokebName: string[] = [];
    const mokebReservation: number[] = [];

    this.mokebService.getAllList().subscribe(mokebs => {
      const mokebData: MokebDto[] = mokebs.items;
      mokebData.forEach(item => {
        mokebName.push(item.name);
      });

      this.entryExitService.getAllEntryExit().subscribe(entryExits => {
        mokebData.forEach(item => {
          const selectedEntryExit = entryExits.filter(x => x.mokebId === item.id);
          const reservationCount = selectedEntryExit.filter(x => {
            const entryDate = new Date(x.entryDate);
            const exitDate = new Date(x.exitDate);
            return this.startDate <= entryDate && this.endDate >= entryDate;
          }).length;

          mokebReservation.push(reservationCount);
        });

        const backgroundColor = mokebName.map(() => this.getRandomColor(0.2));
        const borderColor = mokebName.map(() => this.getRandomColor());

        this.mokebReserveInRangeData = {
          labels: mokebName,
          datasets: [
            {
              label: 'تعداد پذیرش به هر موکب',
              data: mokebReservation,
              backgroundColor: backgroundColor,
              borderColor: borderColor,
              borderWidth: 1,
            },
          ],
        };
      });
    });
  }

  getRandomColor(opacity: number = 1): string {
    const r = Math.floor(Math.random() * 256);
    const g = Math.floor(Math.random() * 256);
    const b = Math.floor(Math.random() * 256);
    return `rgba(${r}, ${g}, ${b}, ${opacity})`;
  }
}
