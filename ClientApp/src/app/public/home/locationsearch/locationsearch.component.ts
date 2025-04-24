/// <reference types="google.maps" />
import { AfterViewInit, Component, ElementRef, NgZone, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-locationsearch',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './locationsearch.component.html',
})

export class LocationsearchComponent implements AfterViewInit {
  @ViewChild('locationInput') locationInput!: ElementRef;
  // selectedLocation: google.maps.places.PlaceResult | null = null;
  selectedLocation: {
    name: string;
    lat: number;
    lng: number;
  } | null = null;
  constructor(private ngZone: NgZone) {}

  ngAfterViewInit(): void {
    const autocomplete = new google.maps.places.Autocomplete(this.locationInput.nativeElement, {
      types: ['geocode'], // or use ['(cities)'] for city search only
      componentRestrictions: { country: 'in' } // optional: restrict to India
    });

    autocomplete.addListener('place_changed', () => {
      this.ngZone.run(() => {
        const place = autocomplete.getPlace();
    
        // Null check for geometry and location
        if (place.geometry && place.geometry.location) {
          this.selectedLocation = {
            name: place.formatted_address || '',
            lat: place.geometry.location.lat(),
            lng: place.geometry.location.lng()
          };
          console.log('Selected Location:', this.selectedLocation);
        } else {
          console.warn('No geometry data available for the selected place.');
          this.selectedLocation = null;
        }
      });
    });
}
}
